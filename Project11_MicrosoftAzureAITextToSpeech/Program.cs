using System.Threading.Tasks;

string subscriptionKey = "";
string region = "westeurope";
string tokenEndpoint = $"https://{region}.api.cognitive.microsoft.com/sts/v1.0/issueToken";

var token = await GetTokenAsync(subscriptionKey, tokenEndpoint);

var text = "Merhaba! Bugün yeni bir başlangıç yapmak için harika bir gün. \r\nUnutma, küçük adımlar büyük değişimlerin habercisidir. \r\nŞimdi derin bir nefes al ve yoluna devam et!";


await SynthesizeSpeech(token, region, text);



static async Task<string> GetTokenAsync(string subscriptionKey, string tokenEndpoint)
{
    using var client = new System.Net.Http.HttpClient();
    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
    var response = await client.PostAsync(tokenEndpoint, null);
    return await response.Content.ReadAsStringAsync();
}

static async Task SynthesizeSpeech(string token, string region, string text)
{
    using var client = new System.Net.Http.HttpClient();
    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
    client.DefaultRequestHeaders.Add("User-Agent", "AzureTTSClient");
    client.DefaultRequestHeaders.Add("X-Microsoft-OutputFormat", "riff-16khz-16bit-mono-pcm");

    string ssml = $@"
                <speak version='1.0' xml:lang='en-US'>
                    <voice xml:lang='tr-TR' name ='tr-TR-AhmetNeural'>
                        {text}
                    </voice>
                </speak>";

    var content = new System.Net.Http.StringContent(ssml, System.Text.Encoding.UTF8, "application/ssml+xml");
    var result = await client.PostAsync($"https://{region}.tts.speech.microsoft.com/cognitiveservices/v1", content);

    if (result.IsSuccessStatusCode)
    {
        var audioData = await result.Content.ReadAsByteArrayAsync();
        await System.IO.File.WriteAllBytesAsync("output2.wav", audioData);
        System.Console.WriteLine("Speech synthesized to output2.wav");
    }
    else
    {
        var error = await result.Content.ReadAsStringAsync();
        System.Console.WriteLine($"Error: {result.StatusCode}, Details: {error}");
    }
}
