using System.Net.Http;

namespace CardsLandingPage.DataConnection
{
    public class CardsApi
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7018/");
            return client;
        }
        
    }
}
