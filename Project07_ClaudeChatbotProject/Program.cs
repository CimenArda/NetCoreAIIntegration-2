using Project07_ClaudeChatbotProject;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {

        var apiKey = "";

        Console.WriteLine("Welcome to the Claude Chatbot!");
        string prompt = Console.ReadLine();
        
        using var client = new HttpClient();
        client.BaseAddress = new Uri("https://api.anthropic.com/");
        client.DefaultRequestHeaders.Add("x-api-key", apiKey);
        client.DefaultRequestHeaders.Add("anthropic-version", "2023-06-01");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var requestBody = new
        {
            model = "claude-sonnet-4-20250514",
            max_tokens = 1000,
            temperature = 0.7,
            messages = new[]
            {
                new { role = "user", content = prompt }
            }
        };


        var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("v1/messages", jsonContent);
        var responseString = await  response.Content.ReadAsStringAsync();
        var claudeResponse = JsonSerializer.Deserialize<ClaudeResponse>(responseString);
        var responseText = claudeResponse.content[0].text;

        Console.WriteLine("Claude's response:");
        Console.WriteLine(responseText);
        Console.WriteLine("Press any key to exit.");




    }
}