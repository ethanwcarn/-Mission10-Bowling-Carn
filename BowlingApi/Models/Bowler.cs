namespace BowlingApi.Models;

/// Represents a single bowler from the BowlingLeague database.
public class Bowler
{
    /// The primary key for the bowler.
    public int BowlerId { get; set; }

    /// The bowler's last name.
    public string BowlerLastName { get; set; } = string.Empty;

    /// The bowler's first name.
    public string BowlerFirstName { get; set; } = string.Empty;

    /// The bowler's middle initial (may be blank).
    public string? BowlerMiddleInit { get; set; }

    /// Street address for the bowler.
    public string BowlerAddress { get; set; } = string.Empty;

    /// City for the bowler's address.
    public string BowlerCity { get; set; } = string.Empty;

    /// Two-character state abbreviation.
    public string BowlerState { get; set; } = string.Empty;

    /// ZIP code for the bowler's address.
    public string BowlerZip { get; set; } = string.Empty;

    /// Phone number for the bowler.
    public string BowlerPhoneNumber { get; set; } = string.Empty;

    /// Foreign key to the bowler's team.
    public int TeamId { get; set; }

    /// Navigation property for the bowler's team.
    public Team? Team { get; set; }
}

