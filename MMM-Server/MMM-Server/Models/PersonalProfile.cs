using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace MMM_Server.Models;

public class PersonalProfile
{
    [RegularExpression(@"^MMM-PPR-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: MMM-PPR-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!;
    
    public string? MInstanceID { get; set; } = null!;

    public string? HumanID { get; set; } = null!;

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? PersonalProfileID { get; set; }
            
    public PersonalProfileData? PersonalProfileData { get; set; } = null!;

    public string? DescrMetadata { get; set; } = null!;

}

public class PersonalProfileData
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public decimal Age { get; set; }

    public string Nationality { get; set; } = null!;

    public string Email { get; set; } = null!;

}


