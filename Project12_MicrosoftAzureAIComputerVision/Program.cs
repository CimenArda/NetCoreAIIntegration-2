
using System.Text.Json;

string imagePath = @"C:\Users\arda1\OneDrive\Masaüstü\basketbol.jpg";
string subscriptionKey = "";
string endpoint = "https://arda-computer-vision.cognitiveservices.azure.com/";

var apiUrl = new Uri(new Uri(endpoint), "vision/v3.2/analyze").ToString();

string requestParameters = "visualFeatures=Categories,Description,Color&language=en";
string uri = $"{apiUrl}?{requestParameters}";
if (!System.IO.File.Exists(imagePath))
{
    System.Console.WriteLine($"Image file not found: {imagePath}");
    return;
}
byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
using var client = new System.Net.Http.HttpClient();
using(ByteArrayContent content = new ByteArrayContent(imageBytes))
{
    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

    HttpResponseMessage response = await client.PostAsync(uri, content);
    string result = await response.Content.ReadAsStringAsync();
    if (response.IsSuccessStatusCode)
    {
        System.Console.WriteLine("Image analysis result:");
        JsonDocument jsonDoc = JsonDocument.Parse(result);
        var description = jsonDoc.RootElement.GetProperty("description");
        var captions = description.GetProperty("captions");
        foreach (var caption in captions.EnumerateArray())
        {
            var text = caption.GetProperty("text").GetString();
            var confidence = caption.GetProperty("confidence").GetDecimal();
            
            var lastConfidence = Math.Round(confidence * 100, 2);
            System.Console.WriteLine($"Caption: {text}, Confidence: {lastConfidence}");
        }
    }
    else
    {
        System.Console.WriteLine($"Error: {response.StatusCode}, Details: {result}");
    }
}