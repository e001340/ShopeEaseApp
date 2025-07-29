using System.Net.Http.Json;
using System.Text.Json;

namespace ShopEase.Blazor.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<string?> LoginAsync(string username, string password)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", new { username, password });
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            return doc.RootElement.GetProperty("accessToken").GetString();
        }
    }
}
