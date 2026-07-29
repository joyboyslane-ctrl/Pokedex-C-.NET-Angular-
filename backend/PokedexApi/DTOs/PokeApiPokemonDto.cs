using System.Text.Json.Serialization;

namespace PokedexApi.DTOs;

public class PokeApiPokemonDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Height { get; set; }
    public int Weight { get; set; }
    public PokeApiSpritesDto Sprites { get; set; } = new();
    public List<PokeApiTypeSlotDto> Types { get; set; } = new();
    public List<PokeApiAbilitySlotDto> Abilities { get; set; } = new();
}

public class PokeApiSpritesDto
{
    [JsonPropertyName("front_default")]
    public string? FrontDefault { get; set; }
}

public class PokeApiTypeSlotDto
{
    public PokeApiNamedResourceDto Type { get; set; } = new();
}
public class PokeApiAbilitySlotDto
{
    public PokeApiNamedResourceDto Ability { get; set; } = new();
}