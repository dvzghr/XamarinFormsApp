using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Portable.HttpClient;

namespace XamarinFormsApp.Service
{
    class QuotesServices
    {
        public static IList<string> GetQuotes()
        {
            var uri = new Uri("https://andruxnet-random-famous-quotes.p.mashape.com/");
            using (var client = new RestClient())
            {
                
            }
            return null;
        }
    }
}
