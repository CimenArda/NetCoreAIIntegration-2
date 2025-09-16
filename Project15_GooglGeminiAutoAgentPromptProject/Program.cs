
using System.Text.Json;

string apiKey = "";
string model = "gemini-1.5-pro";
string endpoint = $"https://generativelanguage.googleapis.com/v1/models/{model}:generateContent?key={apiKey}";


string context = "You are an AI content planner. You will help the user generate content based on their idea. After receiving the idea, you will guide the user by asking the right questions and finally create the content plan in Turkish.";

Console.WriteLine("Bir Fikrin Mi Var ? (Örnek:Bir kafe açmak):");

string userInput = Console.ReadLine();

string UserPrompt = $"{context}\nUser: {userInput}\n Now step by step ask him question:";


for(int i = 0; i < 5; i++)
{
    string question = await SendToGemini(apiKey,endpoint,UserPrompt);

    Console.WriteLine($"Ajan:" + question);

    Console.Write("Kullanıcı:");
    string answer = Console.ReadLine();

    UserPrompt += $"\n Kullanıcı Cevabı: {answer}\n Yeni sorunu sor:";
}

string finalPrompt = $"{UserPrompt}\n Now create a content plan for the user idea in turkish:";

string finalOutput = await SendToGemini(apiKey, endpoint, finalPrompt);

Console.WriteLine("İçerik Planı:" + finalOutput);



static async Task<string> SendToGemini(string apiKey,string endpoint, string prompt)
{
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
                        text = prompt
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
        return answer;
    }
    catch (Exception ex)
    {
        return $"Error parsing response: {ex.Message}";
    }
}