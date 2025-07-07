namespace JoyJourney.Data.Entities;

using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int BirthYear { get; set; } = default!;
    public string Country { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string FullName => FirstName + " " + LastName;
    public int Age => DateTime.Now.Year - BirthYear;

    public List<JournalEntry> JournalEntries { get; set; } = new();
}
