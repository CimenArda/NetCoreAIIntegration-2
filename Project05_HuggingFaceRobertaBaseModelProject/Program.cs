using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {

        var apiKey = "";


        Console.Write("------------Question Area ------------------");
        Console.WriteLine();
        Console.WriteLine("Enter your question!");
        var question = Console.ReadLine();



        Console.Write("------------Context Area ------------------");
        Console.WriteLine();
        Console.WriteLine("Enter your context!");
        var context = Console.ReadLine();


            using(var client =  new HttpClient()) {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

            var requestBody = new
            {
                inputs = new
                {
                    question = question,
                    context = context
                }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = client.PostAsync("https://api-inference.huggingface.co/models/deepset/roberta-base-squad2", content).Result;

            var responseString = await response.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(responseString);


            double score = 0;
            if (doc.RootElement.TryGetProperty("score", out var scoreEl) && scoreEl.TryGetDouble(out var s))
                score = s; // 0.0–1.0 arası
            

            
            // Yüzde formatla
            var percent = (score * 100).ToString("0.00");

            if (doc.RootElement.TryGetProperty("answer", out JsonElement answerElement))
            {
                Console.WriteLine();
                Console.WriteLine("--------------------------------------");
                var answer = answerElement.GetString();
                Console.WriteLine($"Answer: {answer}");

                if (score > 0.5)
                {
                    Console.WriteLine($"Confidence Score: {percent}%");
                }
                else
                {
                    Console.WriteLine("The model is not confident about the answer.");
                }
            }
            else
            {
                Console.WriteLine("No answer found in the response.");
            }
        }

    }
}