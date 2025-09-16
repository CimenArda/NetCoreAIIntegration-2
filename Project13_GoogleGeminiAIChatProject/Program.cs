

using System.Text.Json;

string apiKey = "";
string model = "gemini-1.5-pro";
string endpoint = $"https://generativelanguage.googleapis.com/v1/models/{model}:generateContent?key={apiKey}";

Console.Write("Sorunuzu yazınız:");
string userInput = Console.ReadLine();

var requestBody = new
{
    contents = new[]
    {
        new
        {
            parts =new[]
            {
                new
                {
                    text = userInput
                }
            }
        }
    }
};

var json = JsonSerializer.Serialize(requestBody);   

var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

using var client = new HttpClient();

client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

var response = await client.PostAsync(endpoint, content);

var responseText = await response.Content.ReadAsStringAsync();

try
{
    var doc = JsonDocument.Parse(responseText);
    string answer = doc.RootElement.GetProperty("candidates")[0].GetProperty("content").GetProperty("parts")[0].GetProperty("text").GetString();
    Console.WriteLine(answer);
}
catch (Exception ex)
{

    Console.WriteLine($"Error parsing response: {ex.Message}");
    
}