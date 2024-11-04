namespace MPE.Models
{
    public class Product
    {
        public Guid id { get; set; }
        public string ProductName { get; set; }

        public string MaxVolume { get; set; }

        public string ProductDescription { get; set; }
        public int price { get; set; }

        public string ProducUrl { get; set; }
    }
}
