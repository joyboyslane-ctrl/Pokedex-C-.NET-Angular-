namespace PokedexApi.Services;

public class WeaknessInfo
{
    public string Name { get; set; } = string.Empty;
    public string NameDe { get; set; } = string.Empty;
}

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

    private static readonly Dictionary<string, string> GermanNames = new()
    {
        { "normal", "Normal" }, { "fire", "Feuer" }, { "water", "Wasser" },
        { "electric", "Elektro" }, { "grass", "Pflanze" }, { "ice", "Eis" },
        { "fighting", "Kampf" }, { "poison", "Gift" }, { "ground", "Boden" },
        { "flying", "Flug" }, { "psychic", "Psycho" }, { "bug", "Käfer" },
        { "rock", "Gestein" }, { "ghost", "Geist" }, { "dragon", "Drache" },
        { "dark", "Unlicht" }, { "steel", "Stahl" }, { "fairy", "Fee" }
    };

    public static List<WeaknessInfo> GetWeaknesses(List<string> pokemonTypes)
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

        return weaknesses.Select(w => new WeaknessInfo
        {
            Name = w,
            NameDe = GermanNames.TryGetValue(w, out var de) ? de : w
        }).ToList();
    }
}