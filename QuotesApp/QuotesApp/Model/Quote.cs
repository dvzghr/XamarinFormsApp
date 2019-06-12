using Newtonsoft.Json;

namespace QuotesApp.Model
{
    public class Quote
    {
        [JsonProperty(PropertyName = "quote")]
        public string Line { get; set; }
        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }    
    }
}
