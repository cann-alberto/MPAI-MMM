using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace MMM_Server.Models;

public class Discovery
{
    [RegularExpression(@"^MMM-DIS-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: MMM-DIS-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!; 

    public string? MInstanceID { get; set; } = null!; 

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? DiscoveryID { get; set; } 

    [BsonSerializer(typeof(GenericBsonSerializer))]
    public object? DiscoveryQualifier { get; set; } = null;
   
    public string? DescrMetadata { get; set; } = null!; 
}

public class BasicDiscovery
{
    [RegularExpression(@"^MMM-BDV-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: MMM-BDV-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!;

    public string? MInstanceID { get; set; } = null!;

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? BasicDiscoveryID { get; set; }

    public BasicDiscoveryData? BasicDiscoveryData { get; set; }=null!;

    public string? DescrMetadata { get; set; } = null!;
}

public class BasicDiscoveryData
{
    public DiscoveryRequest? DiscoveryRequest { get; set; } = null!;
    
    public DiscoveryResponse? DiscoveryResponse{ get; set; } = null!;

}

public class DiscoveryRequest 
{
    public string? RequestText { get; set; } = null!;

    public string? ItemID { get; set; } = null!;

    public PerceptibleEntity? PerceptibleEntity { get; set; } = null!;

    public string? ProcessID { get; set; } = null!;

    public Right? ModelRights {get; set; } = null!;
}
public class DiscoveryResponse
{
    public List<ItemData>? Items { get; set; } = null!;

    public List<string>? Processes { get; set; } = null!;

    public List<Right>? OutRights { get; set; } = null!;

}

public class ItemData
{
    public string? ItemID { get; set; }= null!;
    
    public PerceptibleEntity? PerceptibleEntity { get; set; } = null!;

    public string? MLocationID { get; set; } = null!;
}