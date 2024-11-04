using MPE.Models;

namespace MPE.Repository
{
    public interface IProduct
    {
         Task<Product> CreateAsync(Product product);

        Task<Product> UpdateAsync(Product product,Guid id );
        Task<Product> DeleteAsync(Guid id);

        Task<Product> GetByIdAsync(Guid id);


        Task<Product> GetByNameAsync(string name);



       
    }
}
