using Microsoft.EntityFrameworkCore;

namespace PokedexApi;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Pokemon> Pokemon { get; set; }
}