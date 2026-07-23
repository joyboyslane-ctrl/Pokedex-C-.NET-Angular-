using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;
using PokedexApi.DTOs;

namespace PokedexApi.Services;

public class PokeApiSyncService
{
    private readonly HttpClient _http;
    private readonly AppDbContext _db;

    public PokeApiSyncService(HttpClient http, AppDbContext db)
    {
        _http = http;
        _db = db;
    }

    public async Task<int> SyncPokemonAsync(int limit)
    {
        int added = 0;

        for (int id = 1; id <= limit; id++)
        {
            var dto = await _http.GetFromJsonAsync<PokeApiPokemonDto>($"pokemon/{id}");
            if (dto == null) continue;

            bool exists = await _db.Pokemon.AnyAsync(p => p.Id == dto.Id);
            if (exists) continue;

            var pokemon = new Pokemon
            {
                Id = dto.Id,
                Name = dto.Name,
                SpriteUrl = dto.Sprites.FrontDefault,
                HeightDm = dto.Height,
                WeightHg = dto.Weight
            };

            _db.Pokemon.Add(pokemon);
            added++;
        }

        await _db.SaveChangesAsync();
        return added;
    }
}