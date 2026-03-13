using BowlingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BowlingApi.Data;

/// Entity Framework Core database context for the BowlingLeague SQLite database.
public class BowlingLeagueContext : DbContext
{
    /// Initializes a new instance of the context using dependency injection options.
    /// <param name="options">The options that control how the context connects to the database.</param>
    public BowlingLeagueContext(DbContextOptions<BowlingLeagueContext> options)
        : base(options)
    {
    }

    /// Bowlers table from the BowlingLeague database.
    public DbSet<Bowler> Bowlers => Set<Bowler>();

    /// Teams table from the BowlingLeague database.
    public DbSet<Team> Teams => Set<Team>();

    /// Configures table mappings and relationships that differ from EF Core conventions.
    /// <param name="modelBuilder">Fluent API builder for configuring the model.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Map entities to the exact table names used in the existing SQLite database.
        modelBuilder.Entity<Bowler>().ToTable("Bowlers");
        modelBuilder.Entity<Team>().ToTable("Teams");

        // Configure the one-to-many relationship between Team and Bowler.
        modelBuilder.Entity<Bowler>()
            .HasOne(b => b.Team)
            .WithMany(t => t.Bowlers)
            .HasForeignKey(b => b.TeamId);
    }
}

