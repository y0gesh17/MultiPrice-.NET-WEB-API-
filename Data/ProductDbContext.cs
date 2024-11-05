using Microsoft.EntityFrameworkCore;
using MPE.Migrations;
using MPE.Models;
using MPE.Repository;
using static System.Reflection.Metadata.BlobBuilder;
using UserData = MPE.Models.UserData;


namespace MPE.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<UserData> userData { get; set; }

        public DbSet<Bucket> buckets { get; set; }

        public DbSet<Product> products { get; set; }

        public DbSet<Slot> slots { get; set; }

        public void Seed()
        {
            if (!products.Any())
            {

                var product1 = new List<Product>
{
    new Product { id = Guid.NewGuid(), ProductName = "Product A", MaxVolume = "500ml", ProductDescription = "A description of Product A", price = 100, ProducUrl = "http://example.com/productA" },
    new Product { id = Guid.NewGuid(), ProductName = "Product B", MaxVolume = "1L", ProductDescription = "A description of Product B", price = 150, ProducUrl = "http://example.com/productB" },
    new Product { id = Guid.NewGuid(), ProductName = "Product C", MaxVolume = "750ml", ProductDescription = "A description of Product C", price = 200, ProducUrl = "http://example.com/productC" },
    new Product { id = Guid.NewGuid(), ProductName = "Product D", MaxVolume = "500ml", ProductDescription = "A description of Product D", price = 120, ProducUrl = "http://example.com/productD" },
    new Product { id = Guid.NewGuid(), ProductName = "Product E", MaxVolume = "250ml", ProductDescription = "A description of Product E", price = 80, ProducUrl = "http://example.com/productE" },
    new Product { id = Guid.NewGuid(), ProductName = "Product F", MaxVolume = "1.5L", ProductDescription = "A description of Product F", price = 250, ProducUrl = "http://example.com/productF" },
    new Product { id = Guid.NewGuid(), ProductName = "Product G", MaxVolume = "2L", ProductDescription = "A description of Product G", price = 300, ProducUrl = "http://example.com/productG" },
    new Product { id = Guid.NewGuid(), ProductName = "Product H", MaxVolume = "500ml", ProductDescription = "A description of Product H", price = 110, ProducUrl = "http://example.com/productH" },
    new Product { id = Guid.NewGuid(), ProductName = "Product I", MaxVolume = "1L", ProductDescription = "A description of Product I", price = 180, ProducUrl = "http://example.com/productI" },
    new Product { id = Guid.NewGuid(), ProductName = "Product J", MaxVolume = "750ml", ProductDescription = "A description of Product J", price = 140, ProducUrl = "http://example.com/productJ" },
    new Product { id = Guid.NewGuid(), ProductName = "Product K", MaxVolume = "1L", ProductDescription = "A description of Product K", price = 160, ProducUrl = "http://example.com/productK" },
    new Product { id = Guid.NewGuid(), ProductName = "Product L", MaxVolume = "250ml", ProductDescription = "A description of Product L", price = 90, ProducUrl = "http://example.com/productL" },
    new Product { id = Guid.NewGuid(), ProductName = "Product M", MaxVolume = "500ml", ProductDescription = "A description of Product M", price = 130, ProducUrl = "http://example.com/productM" },
    new Product { id = Guid.NewGuid(), ProductName = "Product N", MaxVolume = "1.25L", ProductDescription = "A description of Product N", price = 190, ProducUrl = "http://example.com/productN" },
    new Product { id = Guid.NewGuid(), ProductName = "Product O", MaxVolume = "1L", ProductDescription = "A description of Product O", price = 210, ProducUrl = "http://example.com/productO" },
    new Product { id = Guid.NewGuid(), ProductName = "Product P", MaxVolume = "750ml", ProductDescription = "A description of Product P", price = 170, ProducUrl = "http://example.com/productP" },
    new Product { id = Guid.NewGuid(), ProductName = "Product Q", MaxVolume = "2L", ProductDescription = "A description of Product Q", price = 270, ProducUrl = "http://example.com/productQ" },
    new Product { id = Guid.NewGuid(), ProductName = "Product R", MaxVolume = "1.5L", ProductDescription = "A description of Product R", price = 230, ProducUrl = "http://example.com/productR" },
    new Product { id = Guid.NewGuid(), ProductName = "Product S", MaxVolume = "500ml", ProductDescription = "A description of Product S", price = 120, ProducUrl = "http://example.com/product1" },
    new Product { id = Guid.NewGuid(), ProductName = "Product T", MaxVolume = "750ml", ProductDescription = "A description of Product T", price = 150, ProducUrl = "http://example.com/productT" }
};

                products.AddRange(product1);
                SaveChanges();

                var slots1 = new List<Slot>
{
    new Slot { SlotId = Guid.NewGuid(), ProductId = product1[0].id, CurrentSlotSize = 20, DiscountInPercent = 5, MaximumSlotSize = 50, product = product1[0] },
    new Slot { SlotId = Guid.NewGuid(), ProductId = product1[1].id, CurrentSlotSize = 10, DiscountInPercent = 10, MaximumSlotSize = 30, product = product1[1] },
    new Slot { SlotId = Guid.NewGuid(), ProductId = product1[2].id, CurrentSlotSize = 15, DiscountInPercent = 7, MaximumSlotSize = 40, product = product1[2] },
    new Slot { SlotId = Guid.NewGuid(), ProductId = product1[3].id, CurrentSlotSize = 5, DiscountInPercent = 4, MaximumSlotSize = 25, product = product1[3] },
    new Slot { SlotId = Guid.NewGuid(), ProductId = product1[4].id, CurrentSlotSize = 30, DiscountInPercent = 8, MaximumSlotSize = 60, product = product1[4] },
    new Slot { SlotId = Guid.NewGuid(), ProductId = product1[5].id, CurrentSlotSize = 25, DiscountInPercent = 9, MaximumSlotSize = 55, product = product1[5] },
    new Slot { SlotId = Guid.NewGuid(), ProductId = product1[6].id, CurrentSlotSize = 35, DiscountInPercent = 6, MaximumSlotSize = 70, product = product1[6] },
    new Slot { SlotId = Guid.NewGuid(), ProductId = product1[7].id, CurrentSlotSize = 40, DiscountInPercent = 12, MaximumSlotSize = 75, product = product1[7] },
    new Slot { SlotId = Guid.NewGuid(), ProductId = product1[8].id, CurrentSlotSize = 20, DiscountInPercent = 10, MaximumSlotSize = 50, product = product1[8] },
    new Slot { SlotId = Guid.NewGuid(), ProductId = product1[9].id, CurrentSlotSize = 45, DiscountInPercent = 15, MaximumSlotSize = 80, product = product1[9] },
    new Slot { SlotId = Guid.NewGuid(), ProductId = product1[10].id, CurrentSlotSize = 50, DiscountInPercent = 20, MaximumSlotSize = 100, product = product1[10] },
    new Slot { SlotId = Guid.NewGuid(), ProductId = product1[11].id, CurrentSlotSize = 55, DiscountInPercent = 10, MaximumSlotSize = 110, product = product1[11] },
    new Slot { SlotId = Guid.NewGuid(), ProductId = product1[12].id, CurrentSlotSize = 60, DiscountInPercent = 18, MaximumSlotSize = 120, product = product1[12] },
    new Slot { SlotId = Guid.NewGuid(), ProductId = product1[13].id, CurrentSlotSize = 30, DiscountInPercent = 7, MaximumSlotSize = 60, product = product1[13] },
    new Slot { SlotId = Guid.NewGuid(), ProductId = product1[14].id, CurrentSlotSize = 20, DiscountInPercent = 3, MaximumSlotSize = 50, product = product1[14] },
    new Slot { SlotId = Guid.NewGuid(), ProductId = product1[15].id, CurrentSlotSize = 25, DiscountInPercent = 4, MaximumSlotSize = 55, product = product1[15] },
    new Slot { SlotId = Guid.NewGuid(), ProductId = product1[16].id, CurrentSlotSize = 45, DiscountInPercent = 14, MaximumSlotSize = 90, product = product1[16] },
    new Slot { SlotId = Guid.NewGuid(), ProductId = product1[17].id, CurrentSlotSize = 15, DiscountInPercent = 5, MaximumSlotSize = 40, product = product1[17] },
    new Slot { SlotId = Guid.NewGuid(), ProductId = product1[18].id, CurrentSlotSize = 10, DiscountInPercent = 2, MaximumSlotSize = 35, product = product1[18] },
    };

                slots.AddRange(slots1);
                SaveChanges();
            }
        }
}
}
