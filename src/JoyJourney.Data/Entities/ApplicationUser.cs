
using Microsoft.AspNetCore.Identity;

namespace JoyJourney.Data.Entities;
public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int BirthYear { get; set; } = 0;
    public string Country { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public string FullName => FirstName + " " + LastName;
    public int Age => DateTime.UtcNow.Year - BirthYear;

    public List<JournalEntry> JournalEntries { get; set; } = [];
}
