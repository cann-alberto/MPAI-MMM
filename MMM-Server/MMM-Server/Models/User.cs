using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MMM_Server.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UserID { get; set; }
        public string HumanID { get; set; } = null!;
        public string? ComIp { get; set; }
        public string? ComPort { get; set; } 

    }
}
