using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MMM_Server.Models
{
    public class ActionResponse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ActionResponseID { get; set; }        
        public string Time { get; set; } = null!;
        public string Action { get; set; } = null!;
        public string SProcess { get; set; } = null!;
        public string DProcess { get; set; } = null!;
    }


}
