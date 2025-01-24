using MongoDB.Bson.Serialization.Attributes;

namespace CourseStore.Query.Shared
{
    public class BaseReadModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int Id { get; set; }
        public DateTime CreationDate { get; }
        public BaseReadModel()
        {
            CreationDate= DateTime.MinValue;
        }
    }
}
