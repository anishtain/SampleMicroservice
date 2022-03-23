using MongoDB.Bson.Serialization.Attributes;

namespace CatalogMicroservice.Api.Entities
{
    public class ProductEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
    }
}
