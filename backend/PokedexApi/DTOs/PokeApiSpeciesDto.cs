using System.Text.Json.Serialization;

namespace PokedexApi.DTOs;

public class PokeApiSpeciesDto
{
    public List<PokeApiNameDto> Names { get; set; } = new();

    [JsonPropertyName("flavor_text_entries")]
    public List<PokeApiFlavorTextDto> FlavorTextEntries { get; set; } = new();

    public PokeApiNamedResourceDto Generation { get; set; } = new();
}

public class PokeApiNameDto
{
    public string Name { get; set; } = string.Empty;
    public PokeApiLanguageDto Language { get; set; } = new();
}

public class PokeApiFlavorTextDto
{
    [JsonPropertyName("flavor_text")]
    public string FlavorText { get; set; } = string.Empty;
    public PokeApiLanguageDto Language { get; set; } = new();
}

public class PokeApiLanguageDto
{
    public string Name { get; set; } = string.Empty;
}

public class PokeApiNamedResourceDto
{
    public string Name { get; set; } = string.Empty;
}