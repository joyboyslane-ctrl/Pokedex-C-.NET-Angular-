using Microsoft.EntityFrameworkCore;

namespace PokedexApi;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Pokemon> Pokemon { get; set; }
    public DbSet<PokeType> PokeTypes { get; set; }
    public DbSet<Ability> Abilities { get; set; }
}