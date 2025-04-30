using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace MMM_Server.Models;

public class Account
{
    [RegularExpression(@"^MMM-ACC-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: MMM-ACC-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!; // Account Header
    
    public string? MInstanceID { get; set; } = null!; // Identifier of M-Instance
    
    public string? MEnvironmentID { get; set; } = null!; // Identifier of M-Environment

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]    
    public string? AccountID { get; set; } // Identifier of Account.

    public string? HumanID { get; set; } = null!; // Identifier of human.
    
    public string? PersonalProfileID { get; set; } = null!; // ID of Personal Profile.

    public List<ProcessData> ProcessData { get; set; } = null; // Set of Process

    public string? DescrMetadata { get; set; } = null!; // Descriptive Metadata

}

public class ProcessData 
{    
    public string? ProcessID { get; set; } = null; // ID of a Process

    public List<string>? RightsID { get; set; } = null; // ID of Rights held by ProcessID.
    
    public List<string>? PersonaID { get; set; } = null!; // Identifier of Persona
}