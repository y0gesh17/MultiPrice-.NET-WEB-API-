namespace MPE.Models
{
    public class Bucket
    {
        public Guid BucketID { get; set; }

        public ICollection<Slot> slot { get; set; }

        public string Name { get; set; }
    }
}
