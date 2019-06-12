using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QuotesApp.Model;
using RestSharp;
using RestSharp.Serialization.Json;

namespace QuotesTest
{
    class Program
    {
        private const string url = "https://andruxnet-random-famous-quotes.p.mashape.com/?cat=movies";

        static void Main(string[] args)
        {
            Console.WriteLine("Fetching quotes...");

            Task.Run(async () =>
                     {
                         var quote = await GetQuoteRestSharp();
                         Console.WriteLine($"Incoming quote from RestSharp:\t{quote.Line}");
                     });

            Task.Run(async () =>
                     {
                         var quote = await GetQuote();
                         Console.WriteLine($"Incoming quote from HttpClient:\t{quote.Line}");
                     });

            Console.WriteLine("Press key...");
            Console.ReadKey();
        }

        private static async Task<Quote> GetQuote()
        {
            var uri = new Uri(url);
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Mashape-Key", "SVRrKUoLRBmshZ7IANqnF4kmkxt7p1kYcMNjsnWxDGnoyCOUwh");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = await client.GetStringAsync(uri);
                var quote = await Task.Run(() => JsonConvert.DeserializeObject<Quote[]>(json));

                return quote.FirstOrDefault();
            }
        }

        private static async Task<Quote> GetQuoteRestSharp()
        {
            var uri = new Uri(url);
            var client = new RestClient(uri);
            //client.AddHandler("application/json", () => new JsonDeserializer());

            var request = new RestRequest();
            request.AddHeader("X-Mashape-Key", "SVRrKUoLRBmshZ7IANqnF4kmkxt7p1kYcMNjsnWxDGnoyCOUwh");
            request.AddHeader("Accept", "application/json");

            var response = await client.ExecutePostTaskAsync<List<Quote>>(request);
            return response.Data.FirstOrDefault();
        }
    }
}