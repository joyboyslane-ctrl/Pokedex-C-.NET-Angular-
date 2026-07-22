namespace PokedexApi;

public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? SpriteUrl { get; set; }
    public int HeightDm { get; set; }
    public int WeightHg { get; set; }
}