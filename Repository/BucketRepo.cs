using Microsoft.EntityFrameworkCore;
using MPE.Data;
using MPE.Migrations.ProductDb;
using MPE.Models;

namespace MPE.Repository
{
    public class BucketRepo : IBucket
    {

        ProductDbContext dbContext;
         public BucketRepo(ProductDbContext dbContext) { 
        
             this.dbContext = dbContext;
        
        }
        public async Task<Bucket> CreateBucket(Bucket bucket)
        {
            await dbContext.buckets.AddAsync(bucket);
            await dbContext.SaveChangesAsync();

            return bucket  ;
        }

        public async Task<Bucket> DeleteBucket(Guid Id)
        {
            var bt = await dbContext.buckets.FirstOrDefaultAsync(x => x.BucketID == Id );

            if (bt == null)
            {
                return null;
            }
            dbContext.buckets.Remove(bt);
            await dbContext.SaveChangesAsync();

            return bt;
        }

        //public async  Task<Bucket> DeleteBucket(Guid  Id)
      
        public async Task<List<Bucket>> GetAllBucket()
        {
            var bt = await dbContext.buckets.ToListAsync();
            return bt;
        }

        public async Task<Bucket> GetBucketById(Guid bucketId)
        {
            var bt = await dbContext.buckets.FirstOrDefaultAsync(x => x.BucketID == bucketId);

            if (bt == null)
            {

                return null;
            }
            return bt;
        }

        public async Task<Bucket> UpdateBucket(Bucket bucket,Guid Id)
        {

            var bt = await dbContext.buckets.FirstOrDefaultAsync(x => x.BucketID == Id);

            if (bt == null)
            {
                return null;
            }

            bt.Name = bucket.Name;
            bt.slot = bucket.slot;

            

            await dbContext.SaveChangesAsync();

            return bt;


        }
    }
}
