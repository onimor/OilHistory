using Newtonsoft.Json;

namespace OilHistory.Web.Business
{
    public class GazpromNeft
    {
        public class Datum
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("product")]
            public Product Product { get; set; }

            [JsonProperty("price")]
            public Price Price { get; set; }
        }

        public class Price
        {
            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("price")]
            public double Value { get; set; }

            [JsonProperty("since")]
            public DateTime Since { get; set; }
        }

        public class Product
        {
            [JsonProperty("emisId")]
            public int EmisId { get; set; }

            [JsonProperty("color")]
            public string Color { get; set; }

            [JsonProperty("shortTitle")]
            public string ShortTitle { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }

        public class Root
        {
            [JsonProperty("data")]
            public List<Datum> Data { get; set; }
        }
    }
}
