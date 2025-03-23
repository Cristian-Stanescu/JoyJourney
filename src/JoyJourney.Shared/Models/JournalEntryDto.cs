using JoyJourney.Data.Entities;

namespace JoyJourney.Shared.Models;

public record JournalEntryDto(string Title, DateTime CreatedAt)
{
    public JournalEntry MapToDomain()
    {
        return new JournalEntry
        {
            Title = Title,
            CreatedAt = CreatedAt,
            UpdatedAt = CreatedAt
        };
    }

    public static JournalEntryDto FromDomain(JournalEntry journalEntry)
    {
        return new JournalEntryDto(journalEntry.Title, journalEntry.CreatedAt);
    }
}
