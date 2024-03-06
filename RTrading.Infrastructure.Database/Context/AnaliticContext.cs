using Microsoft.EntityFrameworkCore;
using RTraiding.Application.Domains.Entities;

namespace RTading.Infrastructure.Database.Context;

public class AnaliticContext: DbContext
{
    public DbSet<Tick> Ticks { get; set; }
    public DbSet<Level> Levels { get; set; }
    public AnaliticContext( DbContextOptions<AnaliticContext> options ) : base( options )
    {
    }

    protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
    {
    }
}