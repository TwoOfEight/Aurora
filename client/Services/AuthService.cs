using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using client.Models;

namespace client.Components.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AuthResponse?> LoginAsync(AuthRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/login", request);

            Console.WriteLine($"Request URL: {_httpClient.BaseAddress}api/Auth/login");
            Console.WriteLine($"Request Body: Username = {request.UserName}, Password = {request.Password}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<AuthResponse>();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Login failed: {response.StatusCode}, Response: {errorContent}");
                throw new HttpRequestException($"Login failed: {response.ReasonPhrase}");
            }
        }


        // Register API Call
        public async Task<AuthResponse?> RegisterAsync(RegisterRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/register", request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<AuthResponse>();
            }
            else
            {
                throw new HttpRequestException($"Registration failed: {response.ReasonPhrase}");
            }
        }
    }
}