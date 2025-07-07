
using JoyJourney.Data.Entities;

namespace JoyJourney.Shared.Models;
public record JournalEntryDto(string Content)
{
    public JournalEntry MapToDomain()
    {
        return new JournalEntry
        {
            Title = $"{DateTime.UtcNow:M}",
            Content = Content,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    public static JournalEntryDto FromDomain(JournalEntry journalEntry)
    {
        return new JournalEntryDto(journalEntry.Content);
    }
}
