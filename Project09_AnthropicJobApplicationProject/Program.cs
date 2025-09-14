
using Project09_AnthropicJobApplicationProject;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
       string apiKey = "";

        string prompt = "Bana 'Yazılım Geliştirici' pozisyonu için hazırlanan,profesyonel ama samimi bir tonda yazılmış,iş başvuru e-postayı yaz.Adım Arda,1 yıllık bir deneyimim mevcut. .Net geliştiricisiyim.";

        using var client = new HttpClient();

        client.BaseAddress = new Uri("https://api.anthropic.com/");
        client.DefaultRequestHeaders.Add("x-api-key", apiKey);
        client.DefaultRequestHeaders.Add("Anthropic-Version", "2023-06-01");
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        var requestBody = new
        {
            model = "claude-sonnet-4-20250514",
            max_tokens = 500,
            temperature = 0.7,
            messages = new[]
           {
                new { role = "user", content = prompt }
            }
        };


        var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json");

        var response = client.PostAsync("v1/messages", jsonContent).Result;

        if (response.IsSuccessStatusCode)
        {
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var claudeResponse = JsonSerializer.Deserialize<ClaudeResponse>(responseContent);
            var responseText = claudeResponse.content[0].text;
            Console.WriteLine("Response from Anthropic API:");
            Console.WriteLine(responseText);
        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode}");
            var errorContent = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(errorContent);
        }

    }
}