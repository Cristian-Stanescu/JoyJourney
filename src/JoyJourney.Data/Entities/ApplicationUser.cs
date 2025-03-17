namespace JoyJourney.Data.Entities;

public class ApplicationUser
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int BirthYear { get; set; } = default!;
    public string Country { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string FullName => FirstName + LastName;
}
