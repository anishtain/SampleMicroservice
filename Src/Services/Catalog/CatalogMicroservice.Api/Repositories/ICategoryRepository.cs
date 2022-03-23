using CatalogMicroservice.Api.Entities;

namespace CatalogMicroservice.Api.Repositories
{
    public interface ICategoryRepository
    {
        Task CreateProduct(ProductEntity product);
        Task<bool> DeleteProduct(string id);
        Task<ProductEntity?> GetProduct(string id);
        Task<IEnumerable<ProductEntity>> GetProducts();
        Task<IEnumerable<ProductEntity>> GetProductsByCategory(string category);
        Task<IEnumerable<ProductEntity>> GetProductsByName(string name);
        Task<bool> UpdateProduct(ProductEntity product);
    }
}