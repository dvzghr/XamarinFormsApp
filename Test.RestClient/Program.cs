using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using RestSharp.Portable;
using unirest_net.http;
using XamarinFormsApp.Model;

namespace Test.RestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** START ***");

            //Task.Run(() =>
            //{
            //    var response = GetQuotes();
            //    Console.WriteLine(response.Result.Line);
            //    Console.ReadKey();

            //});

            Console.WriteLine("Fetching quotes...");

            var response = GetQuotes();
            Console.WriteLine(response.Line);
            Console.ReadKey();
        }

        private static Quote GetQuotes()
        {
            var uri = new Uri("https://andruxnet-random-famous-quotes.p.mashape.com/?cat=movies");
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("https://andruxnet-random-famous-quotes.p.mashape.com/");
                client.DefaultRequestHeaders.Add("X-Mashape-Key", "SVRrKUoLRBmshZ7IANqnF4kmkxt7p1kYcMNjsnWxDGnoyCOUwh");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = client.GetStringAsync(uri).Result;
                var quote = JsonConvert.DeserializeObject<Quote>(json);
                return quote;
            }


            //var uri = new Uri("https://andruxnet-random-famous-quotes.p.mashape.com/?cat=movies");
            //using (var client = new RestSharp.Portable.HttpClient.RestClient(uri))
            //{
            //    var request = new RestRequest(Method.POST);
            //    request.AddHeader("X-Mashape-Key", "SVRrKUoLRBmshZ7IANqnF4kmkxt7p1kYcMNjsnWxDGnoyCOUwh");
            //    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //    request.AddHeader("Accept", "application/json");

            //    var result = await client.Execute<Quote>(request);
            //    return result.Data;
            //}


            //var response = Unirest.post("https://andruxnet-random-famous-quotes.p.mashape.com/?cat=movies")
            //                    .header("X-Mashape-Key", "SVRrKUoLRBmshZ7IANqnF4kmkxt7p1kYcMNjsnWxDGnoyCOUwh")
            //                    .header("Content-Type", "application/x-www-form-urlencoded")
            //                    .header("Accept", "application/json")
            //                    .asJson<Quote>();
            //return response;



        }
    }
}
