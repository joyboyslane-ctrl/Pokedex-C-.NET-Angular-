namespace PokedexApi;

public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? NameDe { get; set; }
    public string? SpriteUrl { get; set; }
    public int HeightDm { get; set; }
    public int WeightHg { get; set; }
    public int Generation { get; set; }
    public string? FlavorText { get; set; }
    public List<PokeType> Types { get; set; } = new();
    public List<Ability> Abilities { get; set; } = new();
}