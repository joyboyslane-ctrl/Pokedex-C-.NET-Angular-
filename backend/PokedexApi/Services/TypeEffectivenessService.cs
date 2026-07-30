namespace PokedexApi.Services;

public static class TypeEffectivenessService
{
    private static readonly Dictionary<string, List<string>> WeakAgainst = new()
    {
        { "normal", new List<string> { "fighting" } },
        { "fire", new List<string> { "water", "ground", "rock" } },
        { "water", new List<string> { "electric", "grass" } },
        { "electric", new List<string> { "ground" } },
        { "grass", new List<string> { "fire", "ice", "poison", "flying", "bug" } },
        { "ice", new List<string> { "fire", "fighting", "rock", "steel" } },
        { "fighting", new List<string> { "flying", "psychic", "fairy" } },
        { "poison", new List<string> { "ground", "psychic" } },
        { "ground", new List<string> { "water", "grass", "ice" } },
        { "flying", new List<string> { "electric", "ice", "rock" } },
        { "psychic", new List<string> { "bug", "ghost", "dark" } },
        { "bug", new List<string> { "fire", "flying", "rock" } },
        { "rock", new List<string> { "water", "grass", "fighting", "ground", "steel" } },
        { "ghost", new List<string> { "ghost", "dark" } },
        { "dragon", new List<string> { "ice", "dragon", "fairy" } },
        { "dark", new List<string> { "fighting", "bug", "fairy" } },
        { "steel", new List<string> { "fire", "fighting", "ground" } },
        { "fairy", new List<string> { "poison", "steel" } }
    };

    public static List<string> GetWeaknesses(List<string> pokemonTypes)
    {
        var weaknesses = new HashSet<string>();
        foreach (var type in pokemonTypes)
        {
            if (WeakAgainst.TryGetValue(type, out var weakList))
            {
                foreach (var w in weakList)
                    weaknesses.Add(w);
            }
        }
        return weaknesses.ToList();
    }
}