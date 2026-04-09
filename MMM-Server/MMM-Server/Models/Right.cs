// V 1.1
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MMM_Server.Models;

public class Right
{
    [Required]
    [RegularExpression(@"^MMM-RGT-V[0-9]{1,2}[.][0-9]{1,2}$")]
    public string Header { get; set; } = null!;

    public string? MInstanceID { get; set; }

    public string? MEnvironmentID { get; set; }

    [Required]
    public string RightID { get; set; } = null!;

    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DeonticVerbType DeonticVerb { get; set; }

    [MinLength(1)]
    public List<PAIDOrPAEntry>? PAIDOrPA { get; set; }

    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public LevelType Level { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public RightStatusType RightStatus { get; set; } = RightStatusType.Model;

    public DataExchangeMetadata? DataExchangeMetadata { get; set; }

    public Trace? Trace { get; set; }

    [MaxLength(2048)]
    public string? DescrMetadata { get; set; }
}

// --- Enum ---

public enum DeonticVerbType
{
    Must,
    May,
    [JsonPropertyName("May Not")]
    MayNot
}

public enum LevelType
{
    Internal,
    Acquired,
    Granted
}

public enum RightStatusType
{
    Model,
    Final
}

// (oneOf: ProcessAction | string) ---

public class PAIDOrPAEntry
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ProcessAction? ProcessAction { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? StringID { get; set; }
}