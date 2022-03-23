using CatalogMicroservice.Api.Data;
using MongoDB.Driver;

namespace CatalogMicroservice.Api.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Data.ICatalogDBContext _context;

        public CategoryRepository(ICatalogDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Entities.ProductEntity>> GetProducts()
        {
            return await _context.Products.Find(x => true).ToListAsync();
        }

        public async Task<IEnumerable<Entities.ProductEntity>> GetProductsByName(string name)
        {
            return await _context.Products.Find(x => x.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<Entities.ProductEntity>> GetProductsByCategory(string category)
        {
            return await _context.Products.Find(x => x.Category == category).ToListAsync();
        }

        public async Task<Entities.ProductEntity?> GetProduct(string id)
        {
            return await _context.Products.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateProduct(Entities.ProductEntity product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var deleteResult = await _context.Products.DeleteOneAsync(x => x.Id == id);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> UpdateProduct(Entities.ProductEntity product)
        {
            var updateResult = await _context.Products.ReplaceOneAsync(x => x.Id == product.Id, product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
