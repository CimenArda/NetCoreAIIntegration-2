using System.Net.Http.Headers;
using System.Text.Json;

var apiKey = "a6ff0ee6d343455fbcf96216a43111215c9b870b";
var filePath = "Motivasyon.mp3";

if (!File.Exists(filePath))
{
    Console.WriteLine("File not found: " + filePath);
    return;
}
using var client = new HttpClient();
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", apiKey);

using var fileStream = File.OpenRead(filePath);

var content = new StreamContent(fileStream);
content.Headers.ContentType = new MediaTypeHeaderValue("audio/mp3");

var response = await client.PostAsync("https://api.deepgram.com/v1/listen?model=nova-2-general&language=tr", content);
var json = await response.Content.ReadAsStringAsync();

try
{
    var doc = JsonDocument.Parse(json);
    var transcript = doc.RootElement
        .GetProperty("results")
        .GetProperty("channels")[0]
        .GetProperty("alternatives")[0]
        .GetProperty("transcript")
        .GetString();

    Console.WriteLine("Ses Dosyasının Çıktısı: " + transcript);
}
catch (Exception ex)
{
    Console.WriteLine("Bir hata oluştu: " + ex.Message);    
    throw;
}
