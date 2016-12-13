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
        public string Author { get; set; }
        public string Category { get; set; }    
    }
}
