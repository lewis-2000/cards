using System.Threading.Tasks;
using CardsClientApi;

public class Program
{
    static async Task Main(string[] args)
    {
        var httpClient = new HttpClient();
        var client = new swaggerClient("https://localhost:7018/swagger/v1/swagger.json", httpClient);
        var results = await client.CardDBAllAsync();

        foreach (var item in results)
        {
            Console.WriteLine(item.Id);
        }

    }
    
}