using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MMM_Server.Models
{
    public class Persona
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Model { get; set; } = null!;
    }
}
