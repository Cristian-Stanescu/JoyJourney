namespace JoyJourney.Web;

using System.Net.Http.Headers;
using JoyJourney.Shared.Models;

public class JournalApiClient : HttpClient
{
    public JournalApiClient(HttpClient httpClient)
    {
        httpClient.BaseAddress = new Uri("https://localhost:5001/api/journal");
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<IEnumerable<JournalEntryDto>> GetJournalEntriesAsync()
    {
        await Task.Delay(1000);
        //var response = await GetFromJsonAsync<IEnumerable<JournalEntry>>("");
        return new List<JournalEntryDto>([]);
    }
}
