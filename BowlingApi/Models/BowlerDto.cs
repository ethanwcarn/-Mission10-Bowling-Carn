namespace BowlingApi.Models;

/// Data Transfer Object (DTO) that contains the exact fields the React UI needs
/// for displaying bowler rows in the table.
public class BowlerDto
{
    /// Combined bowler name (First, Middle, Last) ready for display.
    public string BowlerName { get; set; } = string.Empty;

    /// Name of the team the bowler belongs to.
    public string TeamName { get; set; } = string.Empty;

    /// Street address for the bowler.
    public string Address { get; set; } = string.Empty;

    /// City portion of the bowler's address.
    public string City { get; set; } = string.Empty;

    /// Two-character state abbreviation.
    public string State { get; set; } = string.Empty;

    /// ZIP code for the bowler's address.
    public string Zip { get; set; } = string.Empty;

    /// Phone number for the bowler.
    public string PhoneNumber { get; set; } = string.Empty;
}

