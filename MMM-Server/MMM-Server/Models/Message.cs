using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MMM_Server.Models;

public class Message
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? MessageID { get; set; }
    public string Body { get; set; } = null;
    public string Source { get; set; } = null;
    public string Destination { get; set; } = null;    
    public string Time { get; set; } = null!;



}