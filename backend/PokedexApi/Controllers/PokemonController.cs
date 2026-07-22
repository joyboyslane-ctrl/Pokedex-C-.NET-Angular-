using Microsoft.AspNetCore.Mvc;

namespace PokedexApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{

    [HttpGet]
    public IEnumerable<Pokemon> Get()
    {
        return new List<Pokemon>
    {
        new Pokemon { Id = 1, Name = "Bisasam", HeightDm = 7, WeightHg = 69 },
        new Pokemon { Id = 4, Name = "Glumanda", HeightDm = 6, WeightHg = 85 },
        new Pokemon { Id = 7, Name = "Schiggy", HeightDm = 5, WeightHg = 90 }
    };
    }
}