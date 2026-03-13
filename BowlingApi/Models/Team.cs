using System.Collections.Generic;

namespace BowlingApi.Models;

/// Represents a bowling team from the BowlingLeague database.
public class Team
{
    /// The primary key for the team.
    public int TeamId { get; set; }

    /// The display name of the team (for example, Marlins or Sharks).
    public string TeamName { get; set; } = string.Empty;

    /// Navigation collection of bowlers that belong to this team.
    public ICollection<Bowler> Bowlers { get; set; } = new List<Bowler>();
}

