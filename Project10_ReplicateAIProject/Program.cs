

string apiKey = "";
string apiUrl = "https://api.replicate.com/v1/predictions";

Console.WriteLine("Hi! Enter your prompt:");
string prompt = Console.ReadLine();


var requestBody = new
{
    version = "06898b39cb00e42d31666b0dc8b9904f326169768129d756184f65ecf1986c8f",
    input = new
    {
        prompt = prompt
    }
};

var json = System.Text.Json.JsonSerializer.Serialize(requestBody);
using var client = new HttpClient();
client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", apiKey);
client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
Console.WriteLine("Image Creating....");

var response = await client.PostAsync(apiUrl, content);

string responseContent = await response.Content.ReadAsStringAsync();
Console.WriteLine(responseContent);
