using MPE.Models;

namespace MPE.Repository
{
    public interface IBucket
    {

        Task<Bucket> CreateBucket(Bucket bucket);
        Task<Bucket> UpdateBucket(Bucket bucket,Guid Id);

        Task<Bucket> DeleteBucket(Guid Id);

        Task<List<Bucket>> GetAllBucket();

        Task<Bucket> GetBucketById(Guid  bucketId);

    }
}
