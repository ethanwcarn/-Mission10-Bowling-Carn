using BowlingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BowlingApi.Data;

/// <summary>
/// Entity Framework Core database context for the BowlingLeague SQLite database.
/// </summary>
public class BowlingLeagueContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the context using dependency injection options.
    /// </summary>
    /// <param name="options">The options that control how the context connects to the database.</param>
    public BowlingLeagueContext(DbContextOptions<BowlingLeagueContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Bowlers table from the BowlingLeague database.
    /// </summary>
    public DbSet<Bowler> Bowlers => Set<Bowler>();

    /// <summary>
    /// Teams table from the BowlingLeague database.
    /// </summary>
    public DbSet<Team> Teams => Set<Team>();

    /// <summary>
    /// Configures table mappings and relationships that differ from EF Core conventions.
    /// </summary>
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

