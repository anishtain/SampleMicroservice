using CatalogMicroservice.Api.Entities;
using MongoDB.Driver;

namespace CatalogMicroservice.Api.Data
{
    public interface ICatalogDBContext
    {
        IMongoCollection<ProductEntity> Products { get; }
    }
}
