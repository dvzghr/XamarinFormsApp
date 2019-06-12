using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinFormsApp.Model;

namespace XamarinFormsApp.Service
{
    public class QuotesServices
    {
        public async Task<Quote> GetQuote()
        {
            var uri = new Uri("https://andruxnet-random-famous-quotes.p.mashape.com/?cat=movies");
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("https://andruxnet-random-famous-quotes.p.mashape.com/");
                client.DefaultRequestHeaders.Add("X-Mashape-Key", "SVRrKUoLRBmshZ7IANqnF4kmkxt7p1kYcMNjsnWxDGnoyCOUwh");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = await client.GetStringAsync(uri);
                var quote = await Task.Run(() => JsonConvert.DeserializeObject<Quote[]>(json));

                return quote.FirstOrDefault();
            }
        }
    }
}
