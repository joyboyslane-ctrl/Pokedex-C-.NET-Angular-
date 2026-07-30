using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PokedexApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FavoritesController : ControllerBase
{
    private readonly AppDbContext _db;

    public FavoritesController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IEnumerable<Pokemon>> Get()
    {
        return await _db.Favorites
            .Include(f => f.Pokemon)
            .ThenInclude(p => p.Types)
            .Select(f => f.Pokemon)
            .ToListAsync();
    }

    [HttpPost("{pokemonId}")]
    public async Task<IActionResult> Add(int pokemonId)
    {
        bool exists = await _db.Favorites.AnyAsync(f => f.PokemonId == pokemonId);
        if (exists) return Ok("Bereits Favorit.");

        _db.Favorites.Add(new Favorite { PokemonId = pokemonId });
        await _db.SaveChangesAsync();
        return Ok("Zu Favoriten hinzugefügt.");
    }

    [HttpDelete("{pokemonId}")]
    public async Task<IActionResult> Remove(int pokemonId)
    {
        var favorite = await _db.Favorites.FirstOrDefaultAsync(f => f.PokemonId == pokemonId);
        if (favorite == null) return NotFound("Kein Favorit gefunden.");

        _db.Favorites.Remove(favorite);
        await _db.SaveChangesAsync();
        return Ok("Aus Favoriten entfernt.");
    }
}