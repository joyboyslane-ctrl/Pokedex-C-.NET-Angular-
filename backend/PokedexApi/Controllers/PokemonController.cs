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

    [HttpPost("sync")]
    public async Task<string> Sync(int limit = 151)
    {
        int added = await _sync.SyncPokemonAsync(limit);
        return $"{added} neue Pokemon hinzugefügt.";
    }
}