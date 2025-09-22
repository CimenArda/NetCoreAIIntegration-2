

using System.Text.Json;

string apiKey = "";
string engineId = "stable-diffusion-xl-1024-v1-0";
string endpoint = $"https://api.stability.ai/v1/generation/{engineId}/text-to-image";

string prompt = Console.ReadLine();

using var client = new HttpClient();
client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
client.DefaultRequestHeaders.Add("Accept","application/json");

var requestBody = new
{
    text_prompts = new[]
    {
        new
        {
            text = prompt
        }
    },
    cfg_scale = 7,
    clip_guidance_preset = "FAST_BLUE",
    height = 1024,
    width = 1024,
    samples = 1,
    steps = 30
};
var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json");
var response = await client.PostAsync(endpoint, jsonContent);

if (response.IsSuccessStatusCode)
{
    var responseContent = await response.Content.ReadAsStringAsync();
    var jsonDoc = JsonDocument.Parse(responseContent);
    var imageUrl = jsonDoc.RootElement.GetProperty("artifacts")[0].GetProperty("base64").GetString();

    byte[] imageBytes = Convert.FromBase64String(imageUrl);
    string fileName = $"generated_image_{DateTime.Now.Ticks}.png";
    await File.WriteAllBytesAsync(fileName, imageBytes);
    Console.WriteLine("Image saved as: " + fileName);
    
}
else
{
    Console.WriteLine("Error: " + response.StatusCode);
    var errorContent = await response.Content.ReadAsStringAsync();
    Console.WriteLine("Details: " + errorContent);
}