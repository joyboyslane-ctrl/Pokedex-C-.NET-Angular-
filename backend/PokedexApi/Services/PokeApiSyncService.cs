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
        int updated = 0;

        for (int id = 1; id <= limit; id++)
        {
            var dto = await _http.GetFromJsonAsync<PokeApiPokemonDto>($"pokemon/{id}");
            if (dto == null) continue;

            var speciesDto = await _http.GetFromJsonAsync<PokeApiSpeciesDto>($"pokemon-species/{id}");

            string? nameDe = speciesDto?.Names
                .FirstOrDefault(n => n.Language.Name == "de")?.Name;
            string? flavorTextDe = speciesDto?.FlavorTextEntries
                .FirstOrDefault(f => f.Language.Name == "de")?.FlavorText;

            int generation = 1;
            if (speciesDto != null)
            {
                string romanNumeral = speciesDto.Generation.Name.Replace("generation-", "").ToUpper();
                generation = RomanToInt(romanNumeral);
            }

            var pokeTypes = new List<PokeType>();
            foreach (var typeSlot in dto.Types)
            {
                string typeName = typeSlot.Type.Name;
                var existingType = await _db.PokeTypes.FirstOrDefaultAsync(t => t.Name == typeName);
                if (existingType == null)
                {
                    existingType = new PokeType { Name = typeName };
                    _db.PokeTypes.Add(existingType);
                    await _db.SaveChangesAsync();
                }
                pokeTypes.Add(existingType);
            }

            var abilities = new List<Ability>();
            foreach (var abilitySlot in dto.Abilities)
            {
                string abilityName = abilitySlot.Ability.Name;
                var existingAbility = await _db.Abilities.FirstOrDefaultAsync(a => a.Name == abilityName);
                if (existingAbility == null)
                {
                    existingAbility = new Ability { Name = abilityName };
                    _db.Abilities.Add(existingAbility);
                    await _db.SaveChangesAsync();
                }
                abilities.Add(existingAbility);
            }

            var existing = await _db.Pokemon
                .Include(p => p.Types)
                .Include(p => p.Abilities)
                .FirstOrDefaultAsync(p => p.Id == dto.Id);

            if (existing == null)
            {
                _db.Pokemon.Add(new Pokemon
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    NameDe = nameDe,
                    SpriteUrl = dto.Sprites.FrontDefault,
                    HeightDm = dto.Height,
                    WeightHg = dto.Weight,
                    Generation = generation,
                    FlavorText = flavorTextDe?.Replace("\n", " ").Replace("\f", " "),
                    Types = pokeTypes,
                    Abilities = abilities
                });
                added++;
            }
            else
            {
                existing.NameDe = nameDe;
                existing.Generation = generation;
                existing.FlavorText = flavorTextDe?.Replace("\n", " ").Replace("\f", " ");
                existing.Types.Clear();
                foreach (var t in pokeTypes)
                    existing.Types.Add(t);
                existing.Abilities.Clear();
                foreach (var a in abilities)
                    existing.Abilities.Add(a);
                updated++;
            }
        }

        await _db.SaveChangesAsync();
        return added + updated;
    }

    private int RomanToInt(string roman)
    {
        var map = new Dictionary<char, int> { { 'I', 1 }, { 'V', 5 }, { 'X', 10 } };
        int result = 0;
        for (int i = 0; i < roman.Length; i++)
        {
            int value = map[roman[i]];
            if (i + 1 < roman.Length && value < map[roman[i + 1]])
                result -= value;
            else
                result += value;
        }
        return result;
    }
}