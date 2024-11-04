using Microsoft.EntityFrameworkCore;
using MPE.Migrations;
using MPE.Models;
using UserData = MPE.Models.UserData;


namespace MPE.Data
{
    public class ProductDbContext: DbContext
    {
        public ProductDbContext(DbContextOptions <ProductDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<UserData> userData { get; set; }

        public DbSet<Bucket> buckets { get; set; }

        public DbSet<Product> products { get; set; }

        public DbSet<Slot> slots { get; set; }
    }
}
