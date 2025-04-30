using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;


namespace MMM_Server.Models;


public class MLocation
{
    [RegularExpression(@"^MMM-MLC-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: MMM-MLC-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!; // Basic M-Location Header
    
    public string? MInstanceID { get; set; } = null!; // Identifier of M-Instance.

    public string? MEnvironmentID { get; set; } = null!; // Identifier of M-Environment.

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    
    public string? MLocationID { get; set; } // Identifier of Basic M-Location.

    public Time? MLocationTime { get; set; } = null;

    public List<string>? MLocationRights { get; set; } = null!;

    public List<MLocation>? MLocations { get; set; } = null!; // Set of Data defining M-Location.

    public List<BasicMLocation>? BasicMLocations { get; set; } = null!; // Set of Data defining M-Location.

    public string? DescrMetadata { get; set; } = null!; // Descriptive Metadata

}


public class BasicMLocation
{
    [RegularExpression(@"^MMM-BML-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: MMM-BML-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!; // Basic M-Location Header
    
    public string? MInstanceID { get; set; } = null!; // Identifier of M-Instance
    
    public string? MEnvironmentID { get; set; } = null!; // Identifier of M-Environment.

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? BasicMLocationID { get; set; } // Identifier of Basic M-Location.

    public SpaceTime? BasicMLocationSpaceTime { get; set; } = null!; // Space-Time of the Basic M-Location.

    public List<string>? BasicMLocationRights { get; set; } = null!; // Actions that may be performed on the Object.

    public List<BasicMLocation>? BasicMLocations { get; set; } = null!; // Set of Data defining Basic-M-Location.

    [BsonSerializer(typeof(GenericBsonSerializer))]
    public object? Qualifier { get; set; } = null!; // Qualifier of Basic M-Location
    
    public string? DescrMetadata { get; set; } = null!; // Descriptive Metadata
}










