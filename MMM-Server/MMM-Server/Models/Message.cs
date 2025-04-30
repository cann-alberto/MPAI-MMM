using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace MMM_Server.Models;

public class Message
{
    [RegularExpression(@"^MMM-MSG-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: MMM-MSG-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!; // Message Header    

    public string? MInstanceID { get; set; } = null!; // Identifier of M-Instance
                                                       
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? MessageID { get; set; } // Identifier of Message.

    public MessageData MessageData { get; set; } = null;

    public string? DescrMetadata { get; set; } = null!; // Descriptive Metadata

    
}


public class MessageData
{
    public string? MessagePayload { get; set; } = null;

    public PayloadData? PayloadData { get; set; } = null;   
}

public class PayloadData 
{
    public int? PayloadLenght { get; set; } = 0;

    public string? PayloadDataUri { get; set; } = null!;    
}



