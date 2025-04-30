using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MMM_Server.Models;

public class Right
{
    public string Header { get; set; } = null!; // Rights Header
    
    public string MInstanceID { get; set; } = null!;    
    
    public string? MEnvironmentID { get; set; } = null!; 
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? RightID { get; set; } // Identifier of Rights.

    [BsonElement("RightsData")]
    public List<RightData> RightsData { get; set; } = null!; // Set of Rights Data

    public string? DescrMetadata { get; set; } = null!; // Descriptive Metadata

}

public class RightData
{  
    [BsonRepresentation(BsonType.String)]
    public LevelTypes? Level { get; set; }

    public string? ProcessActionID { get; set; } = null!;

    public ProcessAction? ProcessAction { get; set; } = null!;
}


public enum LevelTypes
{
    Internal,
    Acquired,
    Granted
}