using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MMM_Server.Models;


public class Profile
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public decimal Age { get; set; }

    public string Nationality{ get; set; } = null!;

    public string Email { get; set; } = null!;

}
