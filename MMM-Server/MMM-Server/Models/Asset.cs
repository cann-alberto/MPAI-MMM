using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace MMM_Server.Models;

public class Asset
{
    [RegularExpression(@"^MMM-ASS-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: MMM-ASS-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!;

    public string? MInstanceID { get; set; } = null!;

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? AssetID { get; set; }

    public AssetData? AssetData { get; set; } = null!;    

    public string? DescrMetadata { get; set; } = null!;
}

public class AssetData
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? SourceItemID { get; set; } = null!;

    public Time? AssetDate { get; set; } = null!;
    
    public List<string>? ProvenanceID { get; set; } = null!;

    public List<Provenance>  Provenance { get; set; } = null!;

}

public class Provenance
{
    [RegularExpression(@"^MMM-PRV-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: MMM-PRV-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!; // Provenance Header

    public string? MInstanceID { get; set; } = null!; //Identifier of M-Instance.

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ProvenanceID { get; set; } // Identifier of Provenance.

    public string? AssetID{ get; set; } // Identifier of the Asset.

    public List<string> ProvenanceData { get; set; } = null!; // The IDs of the Transactions in the Provenance.

    public string? DescrMetadata { get; set; } = null!; // Descriptive Metadata.

}