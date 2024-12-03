using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MMM_Server.Models;

public class Account
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? AccountID { get; set; }

    public string Header { get; set; } = null!;

    public string MInstanceID { get; set; } = null!;

    public string MEnvironmentID { get; set; } = null!;

    public string HumanID { get; set; } = null!;

    public string PersonalProfileID { get; set; } = null!;

    [BsonElement("Rights")]
    public List<Right> Rights { get; set; } = null;

    [BsonElement("Users")]
    public List<User> Users { get; set; } = null;

    [BsonElement("Personae")]
    public List<Persona> Personae { get; set; } = null!;

    public string DescrMetadata { get; set; } = null!;
}