using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace MMM_Server.Models;

public class Authentication
{
    [RegularExpression(@"^MMM-AUT-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: MMM-AUT-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!;

    public string? MInstanceID { get; set; } = null!;
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? AuthenticationID { get; set; } 

    public ServiceAccessData? ServiceAccessData { get; set; } = null;

    public int? AuthenticationDataLength { get; set; } = 0;    

    public string? AuthenticationDataURI { get; set; } = null!; 
    
    public string? DescrMetadata { get; set; } = null!; 
}

public class ServiceAccessData
{
    public AuthenticationRequest? AuthenticationRequest { get; set; } = null !;
    public bool? AuthenticationResponse { get; set; } = false!;
}

public class AuthenticationRequest
{
    public string ItemID { get; set; } = null;

    public PerceptibleEntity PerceptibleEntity { get; set; } = null!;
    
    public string ClaimedIdentityID { get; set; } = null!;
}

