using System.Collections.Generic;

namespace BowlingApi.Models;

/// <summary>
/// Represents a bowling team from the BowlingLeague database.
/// </summary>
public class Team
{
    /// <summary>
    /// The primary key for the team.
    /// </summary>
    public int TeamId { get; set; }

    /// <summary>
    /// The display name of the team (for example, Marlins or Sharks).
    /// </summary>
    public string TeamName { get; set; } = string.Empty;

    /// <summary>
    /// Navigation collection of bowlers that belong to this team.
    /// </summary>
    public ICollection<Bowler> Bowlers { get; set; } = new List<Bowler>();
}

