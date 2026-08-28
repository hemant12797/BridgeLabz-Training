using System.Net.Http.Headers;
using System.Text.Json;

namespace LabelManagement.HttpClients
{
    /// <summary>
    /// Calls GET /api/User/profile/{userId} on the UserManagement service
    /// to retrieve the user's email address for reminder notifications.
    /// </summary>
    public class UserServiceClient : IUserServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public UserServiceClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            var baseUrl = _config["ServiceUrls:UserManagement"] ?? "http://localhost:5001";
            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<string?> GetUserEmailAsync(int userId, string jwtToken)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", jwtToken);

                var response = await _httpClient.GetAsync($"/api/User/profile/{userId}");
                if (!response.IsSuccessStatusCode) return null;

                var json = await response.Content.ReadAsStringAsync();
                var doc = JsonDocument.Parse(json);

                return doc.RootElement
                    .GetProperty("data")
                    .GetProperty("email")
                    .GetString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UserServiceClient] Failed to fetch user email: {ex.Message}");
                return null;
            }
        }
    }
}
