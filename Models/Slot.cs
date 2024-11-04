namespace MPE.Models
{
    public class Slot
    {
        public Guid SlotId { get; set; }
        public Guid ProductId { get; set; }

        public int CurrentSlotSize { get; set; }

        public int DiscountInPercent { get; set; }

        public int MaximumSlotSize { get; set; }

        public Product product { get; set; }
    }
}
