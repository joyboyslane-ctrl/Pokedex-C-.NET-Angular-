namespace PokedexApi;

public class Favorite
{
    public int Id { get; set; }
    public int PokemonId { get; set; }
    public Pokemon Pokemon { get; set; } = null!;
}