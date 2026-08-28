using System.Net.Http.Headers;
using System.Text.Json;

namespace LabelManagement.HttpClients
{
    /// <summary>
    /// Calls GET /api/Notes/all on the NotesManagement service
    /// to find a note's title for use in reminder email notifications.
    /// </summary>
    public class NoteServiceClient : INoteServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public NoteServiceClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            var baseUrl = _config["ServiceUrls:NotesManagement"] ?? "http://localhost:5003";
            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<string?> GetNoteTitleAsync(int noteId, int userId, string jwtToken)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", jwtToken);

                var response = await _httpClient.GetAsync("/api/Notes/all");
                if (!response.IsSuccessStatusCode) return null;

                var json = await response.Content.ReadAsStringAsync();
                var doc = JsonDocument.Parse(json);

                var notes = doc.RootElement.GetProperty("data").EnumerateArray();
                foreach (var note in notes)
                {
                    if (note.GetProperty("noteId").GetInt64() == noteId)
                    {
                        return note.GetProperty("title").GetString();
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[NoteServiceClient] Failed to fetch note title: {ex.Message}");
                return null;
            }
        }
    }
}
