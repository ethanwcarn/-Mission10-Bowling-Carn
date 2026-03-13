namespace BowlingApi.Models;

/// <summary>
/// Data Transfer Object (DTO) that contains the exact fields the React UI needs
/// for displaying bowler rows in the table.
/// </summary>
public class BowlerDto
{
    /// <summary>
    /// Combined bowler name (First, Middle, Last) ready for display.
    /// </summary>
    public string BowlerName { get; set; } = string.Empty;

    /// <summary>
    /// Name of the team the bowler belongs to.
    /// </summary>
    public string TeamName { get; set; } = string.Empty;

    /// <summary>
    /// Street address for the bowler.
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// City portion of the bowler's address.
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Two-character state abbreviation.
    /// </summary>
    public string State { get; set; } = string.Empty;

    /// <summary>
    /// ZIP code for the bowler's address.
    /// </summary>
    public string Zip { get; set; } = string.Empty;

    /// <summary>
    /// Phone number for the bowler.
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;
}

