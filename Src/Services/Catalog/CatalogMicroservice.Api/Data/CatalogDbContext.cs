using CatalogMicroservice.Api.Entities;
using MongoDB.Driver;

namespace CatalogMicroservice.Api.Data
{
    public class CatalogDbContext : ICatalogDBContext
    {
        public CatalogDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("databaseSettings:DatabaseName"));
            Products = database.GetCollection<ProductEntity>(configuration.GetValue<string>("databaseSettings:CollectionName"));

            CategorySeadData.SeadData(Products);
        }

        public IMongoCollection<ProductEntity> Products { get; }
    }
}
