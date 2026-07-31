using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokedexApi.Services;

namespace PokedexApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly PokeApiSyncService _sync;

    public PokemonController(AppDbContext db, PokeApiSyncService sync)
    {
        _db = db;
        _sync = sync;
    }

    [HttpGet]
    public async Task<IEnumerable<Pokemon>> Get(string? search, string? type)
    {
        var query = _db.Pokemon
            .Include(p => p.Types)
            .Include(p => p.Abilities)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p => p.Name.Contains(search) || (p.NameDe != null && p.NameDe.Contains(search)));
        }

        if (!string.IsNullOrWhiteSpace(type))
        {
            query = query.Where(p => p.Types.Any(t => t.Name == type || t.NameDe == type));
        }

        return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pokemon>> GetById(int id)
    {
        var pokemon = await _db.Pokemon
            .Include(p => p.Types)
            .Include(p => p.Abilities)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pokemon == null) return NotFound();

        return Ok(pokemon);
    }

    [HttpPost("sync")]
    public async Task<string> Sync(int start = 1, int end = 1025)
    {
    int added = await _sync.SyncPokemonAsync(start, end);
    return $"{added} Pokemon synchronisiert (Bereich {start}-{end}).";
    }
}