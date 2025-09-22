
using System.Text;
using System.Text.Json;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("OpenAI Code Editor Projesine Hoşgeldiniz!");

Console.WriteLine("Kodunu yaz ve aşağıdaki işlemlerden birini seç:");

Console.WriteLine("1- Açıklama Üret");
Console.WriteLine("2- Refactoring Yap");
Console.WriteLine("3- Test Case Oluştur");

Console.Write("Seçiminiz (1, 2 veya 3): ");
string choice = Console.ReadLine();
Console.WriteLine("Kodunuzu girin (bitirmek için 'END' yaz):");

StringBuilder userCode = new StringBuilder();

string? line;
while ((line = Console.ReadLine()) != null && line.ToUpper() != "END")
{
    userCode.AppendLine(line);
}

string operation = choice switch
{
    "1" => "Açıklama Üret",
    "2" => "Refactoring Yap",
    "3" => "Test Case Oluştur",
    _ => throw new InvalidOperationException("Geçersiz seçim")
};

var result = await AskOpenAI(operation,userCode);
Console.WriteLine("Yanıt:");
Console.WriteLine(result);


static async Task<string> AskOpenAI(string operation,StringBuilder userCode)
{
    string apiKey = "";
    string endpoint = "https://api.openai.com/v1/chat/completions";

     using var client = new HttpClient();
    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

    var systemMessage = new
    {
        role = "system",
        content = "You are a helpful assistant that helps with code."
    };
    var userMessage = new
    {
        role = "user",
        content = $"Lütfen aşağıdaki kod için '{operation}' işlemini gerçekleştir:\n\n{userCode}"
    };
    var requestBody = new
    {
        model = "gpt-4o",
        messages = new[] { systemMessage, userMessage },
        max_tokens = 500,
        temperature = 0.7
    };
    var json = JsonSerializer.Serialize(requestBody);
    var content = new StringContent(json, Encoding.UTF8, "application/json");
   
    var response = await client.PostAsync(endpoint, content);
    var responseString = await response.Content.ReadAsStringAsync();
    using var document = JsonDocument.Parse(responseString);
    var root = document.RootElement;
    var answer = root.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
    return answer ?? "No response from OpenAI.";
}