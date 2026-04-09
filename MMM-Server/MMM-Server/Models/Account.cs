// V 2.1
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace MMM_Server.Models;

public class Account
{
    
    [Required]
    [RegularExpression(@"^MMM-ACC-V[0-9]{1,2}[.][0-9]{1,2}$")]
    public string Header { get; set; } = null!;

    [Required]
    public string MInstanceID { get; set; } = null!;

    [Required]
    public string MEnvironmentID { get; set; } = null!;
    
    [BsonId]
    [Required]
    [BsonRepresentation(BsonType.ObjectId)]
    public string AccountID { get; set; } = null!;

    public string? HumanID { get; set; }

    public string? AccountLevel { get; set; }

    public string? PersonalProfileID { get; set; }

    public List<AccountItem>? Items { get; set; }

    public List<AccountProcess>? Processes { get; set; }

    [MinLength(1)]
    public List<RightsEntry>? Rights { get; set; }
    
    public DataExchangeMetadata? DataExchangeMetadata { get; set; }
        
    public Trace? Trace { get; set; }

    [MaxLength(2048)]
    public string? DescrMetadata { get; set; }
}

public class AccountItem
{
    public string? ItemID { get; set; }
}

public class AccountProcess
{
    public string? ProcessID { get; set; }
}

public class RightsEntry
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Right? Right { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? RightID { get; set; }
}