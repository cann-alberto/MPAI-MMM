using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MMM_Server.Models;

public class Right
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? RightID { get; set; }

    public string Header { get; set; } = null!;

    public string MInstanceID { get; set; } = null!;
    
    [BsonElement("RightsData")]
    public List<RightData> RightsData { get; set; } = null!;

    public string DescrMetadata { get; set; } = null!;
}
