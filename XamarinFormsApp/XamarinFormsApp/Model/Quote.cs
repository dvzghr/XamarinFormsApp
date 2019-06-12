using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XamarinFormsApp.Model
{
    public class Quote
    {
        [JsonProperty("quote")]
        public string Line { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }    
    }
}
