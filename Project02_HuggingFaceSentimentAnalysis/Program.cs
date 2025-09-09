using System.Globalization;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

var apiKey = "";

Console.WriteLine("Enter your comment to analyze sentiment:");
var inputText = Console.ReadLine();

if (string.IsNullOrWhiteSpace(inputText))
{
    Console.WriteLine("Please enter your comment!");
    return;
}
var modelUrl = "https://api-inference.huggingface.co/models/cardiffnlp/twitter-roberta-base-sentiment";



using var client = new HttpClient();    
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

var json = JsonSerializer.Serialize(new
{
    inputs = inputText
});

var content = new StringContent(json,Encoding.UTF8,"application/json");
var response = await client.PostAsync(modelUrl, content);
var result = await response.Content.ReadAsStringAsync();


var doc = JsonDocument.Parse(result);
var items = doc.RootElement[0];

var topLabel = items.EnumerateArray().OrderByDescending(e => e.GetProperty("score").GetDouble()).First();


var label = topLabel.GetProperty("label").GetString();
var score = topLabel.GetProperty("score").GetDouble();

string labelText = label switch
{
    "LABEL_0" => "Negative",
    "LABEL_1" => "Neutral",
    "LABEL_2" => "Positive",
    _ => "Unknown"
};  

Console.WriteLine($"Comment: {inputText}");


Console.WriteLine($"Sentiment Status: {labelText}");
Console.WriteLine($"Trust Score: %{(score * 100).ToString("F2",CultureInfo.InvariantCulture)}");
