using Microsoft.EntityFrameworkCore;
using MPE.Data;
using MPE.Models;

namespace MPE.Repository
{
    public class ProductRepo : IProduct
    {
        private ProductDbContext dbContext;
        public ProductRepo(ProductDbContext dbcontext)
        {
            this.dbContext = dbcontext;
        }
        public async Task<Product>CreateAsync(Product product)
        {
            await dbContext.products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            return product;

        }

        public async  Task<Product> DeleteAsync(Guid  id )
        {
            var product = dbContext.products.FirstOrDefault(x => x.id == id);

            if (product != null)
            {
                dbContext.products.Remove(product);
                await dbContext.SaveChangesAsync();

                return product;
            }

            return null;
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            var product = await  dbContext.products.FirstOrDefaultAsync(x => x.id == id);

            return product == null ? null : product;    
        }

        public async Task<Product> GetByNameAsync(string name)
        {
            var product = await dbContext.products.FirstOrDefaultAsync(x => x.ProductName == name);

            return product == null ? null : product;
        }

        public async Task<Product> UpdateAsync(Product product,Guid id)
        {
            var products = await dbContext.products.FirstOrDefaultAsync(x => x.id== id);

            if (products == null)
            {

                return null;
            }
            products.price = product.price;
            products.ProductDescription = product.ProductDescription;
            products.ProductName = product.ProductName;
            products.ProducUrl = product.ProducUrl;
            await dbContext.SaveChangesAsync();
            return products;



        }
    }
}
