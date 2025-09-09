
using System.Text.Json;

var apiKey = "";

Console.WriteLine("Enter your text to summarize:");

var inputText = Console.ReadLine();

if (string.IsNullOrWhiteSpace(inputText))
{
    Console.WriteLine("Please enter your text!");
    return;
}

var requestData = new
{
    inputs = inputText
};
var json = JsonSerializer.Serialize(requestData);
var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");



using var client = new HttpClient();
client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

var response = await client.PostAsync("https://api-inference.huggingface.co/models/facebook/bart-large-cnn", content);
var result = await response.Content.ReadAsStringAsync();

var doc = JsonDocument.Parse(result);
var summary = doc.RootElement[0].GetProperty("summary_text").GetString();


Console.WriteLine("-------------------");
Console.WriteLine("---------------------------");
Console.WriteLine("Summary: " + summary);


