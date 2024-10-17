using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MMM_Server.Models
{
    public class Device
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

    }
}
