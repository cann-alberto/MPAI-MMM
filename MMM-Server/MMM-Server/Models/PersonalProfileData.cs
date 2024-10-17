using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MMM_Server.Models;


public class PersonalProfileData
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public decimal Age { get; set; }

    public string Nationality{ get; set; } = null!;

    public string Email { get; set; } = null!;

}
