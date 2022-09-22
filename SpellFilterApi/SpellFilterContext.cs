using Microsoft.EntityFrameworkCore;
using SpellFilter.Models;

public class SpellFilterContext : DbContext
{
    public SpellFilterContext(DbContextOptions<SpellFilterContext> options)
        : base(options)
    {
    }
    
    public DbSet<Spell> Spells { get; set; }
}
