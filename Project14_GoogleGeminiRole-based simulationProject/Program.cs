

string apiKey = "";
string model = "gemini-1.5-pro";
string endpoint = $"https://generativelanguage.googleapis.com/v1/models/{model}:generateContent?key={apiKey}";

Console.WriteLine("Rol Seçiniz:");
Console.WriteLine("1- Matematik Öğretmeni");
Console.WriteLine("2- Psikolog");
Console.WriteLine("3- Senior Yazılım Geliştirici");
Console.WriteLine("4- Finansal Yatırım Uzmanı");

Console.WriteLine();
Console.WriteLine("Seçiminiz (1-4):");
string roleChoice = Console.ReadLine();

string role = roleChoice switch
{
    "1" => "You are a helpful math teacher. Explain concepts clearly and provide examples in Turkish.",
    "2" => "You are a compassionate psychologist. Offer thoughtful advice and support in Turkish.",
    "3" => "You are an experienced senior software developer. Share best practices and coding tips in Turkish .",
    "4" => "You are a knowledgeable financial investment expert. Provide sound investment advice in Turkish .",
};

Console.Write("Sorunuzu yazınız:");
string userInput = Console.ReadLine();

string finalInput = $"{role}\nUser: {userInput}\nAssistant:";

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
                    text = finalInput
                }
            }
        }
    }
};

var json = System.Text.Json.JsonSerializer.Serialize(requestBody);
var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

using var client = new HttpClient();

client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

var response = await client.PostAsync(endpoint, content);
var responseText = await response.Content.ReadAsStringAsync();

try
{
    var doc = System.Text.Json.JsonDocument.Parse(responseText);
    string answer = doc.RootElement.GetProperty("candidates")[0].GetProperty("content").GetProperty("parts")[0].GetProperty("text").GetString();
    Console.WriteLine(answer);
}
catch (Exception ex)
{
    Console.WriteLine($"Error parsing response: {ex.Message}");
}

