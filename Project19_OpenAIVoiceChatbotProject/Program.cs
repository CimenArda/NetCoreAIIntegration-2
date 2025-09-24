

using Newtonsoft.Json;

string apiKey = "";
string apiKey2 = "";


    Console.WriteLine("Sesli Chatbot başladı.Konuşmak için 'Enter' tuşuna basın...");

while (true)
{
    Console.ReadLine();
    // Kullanıcının sesini kaydet
    string audioFilePath = "user_input.wav";
    Console.WriteLine("Lütfen konuşun...");
    RecordAudio(audioFilePath);
    // Ses dosyasını metne dönüştür (Whisper Api ile )
    string userInput = await TranscribeAudioAsync(apiKey, audioFilePath);
    Console.WriteLine($"Kullanıcı: {userInput}");
    // ChatGPT ile yanıt oluştur
    string botResponse = GetChatGPTResponse(apiKey2, userInput);
    Console.WriteLine($"Chatbot: {botResponse}");
    // Yanıtı sese dönüştür ve oynat
    var synthesizer = new System.Speech.Synthesis.SpeechSynthesizer();
    synthesizer.Speak(botResponse);
}

static void RecordAudio(string audioFilePath)
{
    using (var waveIn = new NAudio.Wave.WaveInEvent())
    {
        waveIn.WaveFormat = new NAudio.Wave.WaveFormat(16000, 1);
        using (var writer = new NAudio.Wave.WaveFileWriter(audioFilePath, waveIn.WaveFormat))
        {
            waveIn.DataAvailable += (s, a) =>
            {
                writer.Write(a.Buffer, 0, a.BytesRecorded);
            };
            waveIn.StartRecording();
            Console.WriteLine("Konuşmayı bitirmek için 'Enter' tuşuna basın...");
            Console.ReadLine();
            waveIn.StopRecording();
        }
    }
}

static async Task<string> TranscribeAudioAsync(string apiKey, string audioFilePath)
{
    using (var httpClient = new HttpClient())
    {
        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
        using (var form = new MultipartFormDataContent())
        {
            var audioBytes = await File.ReadAllBytesAsync(audioFilePath);
            form.Add(new ByteArrayContent(audioBytes), "file", Path.GetFileName(audioFilePath));
            form.Add(new StringContent("whisper-1"), "model");
            var response = await httpClient.PostAsync("https://api.openai.com/v1/audio/transcriptions", form);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(jsonResponse);
            return result.text;
        }
    }
}

static string GetChatGPTResponse(string apiKey2, string userInput)
{
    using (var httpClient = new HttpClient())
    {
        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey2);
        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
                new { role = "user", content = userInput }
            }
        };
        var jsonRequestBody = JsonConvert.SerializeObject(requestBody);
        var content = new StringContent(jsonRequestBody, System.Text.Encoding.UTF8, "application/json");
        var response = httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content).Result;
        response.EnsureSuccessStatusCode();
        var jsonResponse = response.Content.ReadAsStringAsync().Result;
        dynamic result = JsonConvert.DeserializeObject(jsonResponse);
        return result.choices[0].message.content;
    }
}

