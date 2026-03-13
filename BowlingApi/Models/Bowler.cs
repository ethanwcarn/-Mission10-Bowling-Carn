namespace BowlingApi.Models;

/// <summary>
/// Represents a single bowler from the BowlingLeague database.
/// </summary>
public class Bowler
{
    /// <summary>
    /// The primary key for the bowler.
    /// </summary>
    public int BowlerId { get; set; }

    /// <summary>
    /// The bowler's last name.
    /// </summary>
    public string BowlerLastName { get; set; } = string.Empty;

    /// <summary>
    /// The bowler's first name.
    /// </summary>
    public string BowlerFirstName { get; set; } = string.Empty;

    /// <summary>
    /// The bowler's middle initial (may be blank).
    /// </summary>
    public string? BowlerMiddleInit { get; set; }

    /// <summary>
    /// Street address for the bowler.
    /// </summary>
    public string BowlerAddress { get; set; } = string.Empty;

    /// <summary>
    /// City for the bowler's address.
    /// </summary>
    public string BowlerCity { get; set; } = string.Empty;

    /// <summary>
    /// Two-character state abbreviation.
    /// </summary>
    public string BowlerState { get; set; } = string.Empty;

    /// <summary>
    /// ZIP code for the bowler's address.
    /// </summary>
    public string BowlerZip { get; set; } = string.Empty;

    /// <summary>
    /// Phone number for the bowler.
    /// </summary>
    public string BowlerPhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Foreign key to the bowler's team.
    /// </summary>
    public int TeamId { get; set; }

    /// <summary>
    /// Navigation property for the bowler's team.
    /// </summary>
    public Team? Team { get; set; }
}

