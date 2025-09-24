

using System.Text.Json;

Console.WriteLine("Welcome to the AI video creator app!");
Console.WriteLine("");

Console.Write("Please enter your prompt for video creation: ");

string apiKey = "";
string version = "1e205ea73084bd17a0a3b43396e49ba0d6bc2e754e9283b2df49fad2dcf95755";

string prompt = Console.ReadLine();


using var client = new HttpClient();
client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", apiKey);

var body = new
{
    version,
    input = new
    {
        prompt,
        num_frames = 48,
        fps = 12,
        guidance_scale = 7,
        num_inference_steps = 100,
        width = 1024,
        height = 576,
    }
};

var json = JsonSerializer.Serialize(body);
var response = await client.PostAsync("https://api.replicate.com/v1/predictions", new StringContent(json, System.Text.Encoding.UTF8, "application/json"));

if(!response.IsSuccessStatusCode)
{
    Console.WriteLine("Error: " + response.StatusCode);
    var errorContent = await response.Content.ReadAsStringAsync();
    Console.WriteLine("Details: " + errorContent);
    return;
}
var pred = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
string id = pred.RootElement.GetProperty("id").GetString();
Console.WriteLine("Video generation started....");


//Section 2 Status circling

string status = "";
string videoUrl = "";

while(status != "succeeded" && status != "failed")
{
    await Task.Delay(5000);
    var resp = await client.GetAsync("https://api.replicate.com/v1/predictions/" + id);
    var predResult = JsonDocument.Parse(await resp.Content.ReadAsStringAsync());
    status = predResult.RootElement.GetProperty("status").GetString();
    Console.WriteLine("Status: " + status);
    if (status == "succeeded")
    {
        var output = predResult.RootElement.GetProperty("output");
        if (output.ValueKind == JsonValueKind.Array && output.GetArrayLength() > 0)
        {
            videoUrl = output[0].GetString();
        }
        else if (output.ValueKind == JsonValueKind.String)
        {
            videoUrl = output.GetString();
        }
    }
    else if (status == "failed")
    {
        Console.WriteLine("Video generation failed.");
        return;
    }
}
Console.WriteLine("Video URL: " + videoUrl);


//Section 3 Downloading the video and Otomatic playing it

using var stream = await client.GetStreamAsync(videoUrl);
string fileName = $"generated_video_{DateTime.Now.Ticks}.mp4";

await using var file = File.Create(fileName);
await stream.CopyToAsync(file);
Console.WriteLine("Video saved as: " + fileName);
System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
{
    FileName = fileName,
    UseShellExecute = true
});