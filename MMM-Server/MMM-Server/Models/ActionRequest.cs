using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MMM_Server.Models
{
    public class ActionRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ActionRequestID { get; set; }
        public string Time{ get; set; } = null!;
        public string Source { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public string Action { get; set; } = null!;
        public string InItem { get; set; } = null!;
        public string InLocation { get; set; } = null!;
        public string OutLocation { get; set; } = null!;
        public string RightsID { get; set; } = null!;
    }

    
}
