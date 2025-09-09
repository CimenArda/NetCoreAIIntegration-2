using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        var apiKey = "";
        Console.WriteLine("Enter your text:");
        var inputText = Console.ReadLine(); 

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",apiKey);

            var requestBody = new
            {
                inputs = inputText
            };


            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://api-inference.huggingface.co/models/dslim/bert-base-NER", content);

            var result = await response.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(result);

            Console.WriteLine("{0,-10} | {1,-10} | {2}", "Score", "Entity", "Word");
            Console.WriteLine(new string('-', 40));

            foreach (var item in doc.RootElement.EnumerateArray())
            {
                var entity = item.GetProperty("entity_group").GetString();
                var word = item.GetProperty("word").GetString();
                var score = Math.Round(item.GetProperty("score").GetDouble() * 100,2);


                Console.WriteLine("{0,-10} | {1,-10} | {2}", score + "%", entity, word);


            }



        }
    }

}