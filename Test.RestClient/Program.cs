using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using RestSharp.Portable;
using RestSharp.Portable.Deserializers;
using unirest_net.http;
using XamarinFormsApp.Model;

namespace Test.RestClient
{
    class Program
    {
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
                var quote = await GetQuoteUniRest();
                Console.WriteLine($"Incoming quote from UniRest:\t{quote.Line}");
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
            var uri = new Uri("https://andruxnet-random-famous-quotes.p.mashape.com/?cat=movies");
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("https://andruxnet-random-famous-quotes.p.mashape.com/");
                client.DefaultRequestHeaders.Add("X-Mashape-Key", "SVRrKUoLRBmshZ7IANqnF4kmkxt7p1kYcMNjsnWxDGnoyCOUwh");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = await client.GetStringAsync(uri);
                var quote = await Task.Run(() => JsonConvert.DeserializeObject<Quote>(json));

                //HttpContentExtensions - System.Net.Http.Formatting
                var response = await client.GetAsync(uri);
                var quote2 = await response.Content.ReadAsAsync<Quote>();

                return quote;
            }
        }

        private static async Task<Quote> GetQuoteRestSharp()
        {
            var uri = new Uri("https://andruxnet-random-famous-quotes.p.mashape.com/?cat=movies");
            using (var client = new RestSharp.Portable.HttpClient.RestClient(uri))
            {
                var request = new RestRequest(Method.POST);
                request.AddHeader("X-Mashape-Key", "SVRrKUoLRBmshZ7IANqnF4kmkxt7p1kYcMNjsnWxDGnoyCOUwh");
                //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddHeader("Accept", "application/json");

                var response = await client.Execute<Quote>(request);
                var quote = await Task.Run(() => new JsonDeserializer().Deserialize<Quote>(response));
                return quote;
            }
        }

        private static async Task<Quote> GetQuoteUniRest()
        {
            var response = await Unirest
                .post("https://andruxnet-random-famous-quotes.p.mashape.com/?cat=movies")
                .header("X-Mashape-Key", "SVRrKUoLRBmshZ7IANqnF4kmkxt7p1kYcMNjsnWxDGnoyCOUwh")
                //.header("Content-Type", "application/x-www-form-urlencoded")
                .header("Accept", "application/json")
                .asJsonAsync<string>();

            var quote = await Task.Run(() => JsonConvert.DeserializeObject<Quote>(response.Body));

            return quote;
        }
    }
}
