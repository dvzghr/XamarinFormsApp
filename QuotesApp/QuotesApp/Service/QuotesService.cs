using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QuotesApp.Model;

namespace QuotesApp.Service
{
    public class QuotesService
    {
        private const string url = "https://andruxnet-random-famous-quotes.p.mashape.com/?cat=movies";
        private static HttpClient client;

        public QuotesService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Mashape-Key", "SVRrKUoLRBmshZ7IANqnF4kmkxt7p1kYcMNjsnWxDGnoyCOUwh");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Quote> GetQuote()
        {
            var json = await client.GetStringAsync(url);
            var quote = await Task.Run(() => JsonConvert.DeserializeObject<Quote[]>(json));

            return quote.FirstOrDefault();
        }
    }
}