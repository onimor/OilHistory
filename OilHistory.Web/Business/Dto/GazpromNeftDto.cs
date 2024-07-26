namespace OilHistory.Web.Business.Dto
{
    public class GazpromNeftDto
    {
        public class Datum
        {
            public int Id { get; set; }
            public Product Product { get; set; }
            public PriceValue Price { get; set; }
        }

        public class PriceValue
        {
            public string Currency { get; set; }

            public DateTime Since { get; set; }
        }

        public class Product
        {
            public int EmisId { get; set; }
            public string Color { get; set; }
            public string ShortTitle { get; set; }
            public string Title { get; set; }
            public string Type { get; set; }
        }

        public class Root
        {
            public List<Datum> Data { get; set; }
        }
    }
}
