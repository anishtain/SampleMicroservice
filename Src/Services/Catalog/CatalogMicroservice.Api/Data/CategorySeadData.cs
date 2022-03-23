using CatalogMicroservice.Api.Entities;
using MongoDB.Driver;

namespace CatalogMicroservice.Api.Data
{
    public class CategorySeadData
    {
        public static void SeadData(IMongoCollection<ProductEntity> products)
        {
            bool isExists = products.Find(x => true).Any();

            if (!isExists)
            {
                products.InsertManyAsync(new ProductEntity[]
                {
                    new ProductEntity()
                    {
                        Name = "test1",
                        Description = "test",
                        Category = "t1",
                        Id = "1"
                    },
                    new ProductEntity()
                    {
                        Name = "test2",
                        Description = "test2",
                        Category = "t2",
                        Id = "2"
                    },
                    new ProductEntity()
                    {
                        Name = "test3",
                        Description = "test3",
                        Category = "t3",
                        Id = "3"
                    }
                });
            }
        }
    }
}
