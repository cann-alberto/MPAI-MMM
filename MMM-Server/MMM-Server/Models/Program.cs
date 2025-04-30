using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace MMM_Server.Models;

public class Program
{
    [RegularExpression(@"^MMM-PRG-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: MMM-PRG-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!;

    public string? MInstanceID { get; set; } = null!;

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ProgramID { get; set; }

    [BsonSerializer(typeof(GenericBsonSerializer))]
    public object? ProgramDataQualifier { get; set; } = null!;
    
    public int? ProgramDataLength { get; set; } = 0;

    public string? ProgramDataURI { get; set; } = null!;    

    public string? DescrMetadata { get; set; } = null!;

}