using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using apiTests;

namespace ApiTester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Testing API Endpoints...");

            using HttpClient client = new HttpClient();
            Tester tester = new Tester(client);

            string baseUrl = "http://localhost:5271"; 

            //await tester.Get($"{baseUrl}/api/User");

            var postData = new
            {
                userName = "mack.the.knife",
                password = "api"

            };
            await tester.Post($"{baseUrl}/api/Auth/login", postData);

            Console.WriteLine("API Testing Finished.");
        }
    }
}
