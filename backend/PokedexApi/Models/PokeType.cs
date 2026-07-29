using System.Text.Json.Serialization;

namespace PokedexApi;

public class PokeType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? NameDe { get; set; }

    [JsonIgnore]
    public List<Pokemon> Pokemons { get; set; } = new();
}