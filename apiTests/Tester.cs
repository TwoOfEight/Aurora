using System;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace apiTests;

public class Tester
{
    private readonly HttpClient _client;
    public Tester(HttpClient client)
    {
        _client = client;
    }

    public async Task Get(string url)
    {
        try
        {
            Console.WriteLine($"Sending GET request to {url}...");
            HttpResponseMessage response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response: {content}");
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"GET request failed: {ex.Message}");
        }
    }

    // Method to test a POST request
    public async Task Post(string url, object postData)
    {
        try
        {
            Console.WriteLine($"Sending POST request to {url}...");

            // Serialize the data to JSON
            string jsonData = JsonSerializer.Serialize(postData);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response: {result}");
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"POST request failed: {ex.Message}");
        }
    }

}
