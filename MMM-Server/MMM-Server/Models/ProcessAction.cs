using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Timers;

namespace MMM_Server.Models
{
    public class ProcessAction
    {
        [Required]
        [RegularExpression(@"^MMM-PAC-V[0-9]{1,2}\.[0-9]{1,2}$")]
        public string Header { get; set; } = null!;

        [Required]
        public string MInstanceID { get; set; } = null!;

        [Required]
        public string ProcessActionID { get; set; } = null!;

        public Time? Time { get; set; }

        [Required]
        public List<Preposition> RQComplements { get; set; } = null!;

        public List<Preposition>? RSComplements { get; set; }

        [Required]
        [MinLength(1)]
        public List<PAStatusEntry> PAStatus { get; set; } = null!;

        [MinLength(1)]
        public List<RightsEntry>? Rights { get; set; }

        
        public DataExchangeMetadata? DataExchangeMetadata { get; set; }

        public Trace? Trace { get; set; }

        [MaxLength(2048)]
        public string? DescrMetadata { get; set; }
    }


    // ---------------------------------------------------------------------------
    // PAStatus entry (oneOf: Ack | Request | Error)
    // ---------------------------------------------------------------------------

    public class PAStatusEntry
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Ack { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Value? Request { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PAErrorType? Error { get; set; }
    }

    public enum PAErrorType
    {
        Clash,
        FaultyReq,
        IncID,
        IncDQ,
        InsRights,
        InsValue,
        LocOOR,
        PostRef,
        QualNS
    }


    // ---------------------------------------------------------------------------
    // Prepositions (anyOf: semantic complements framing the action)
    // ---------------------------------------------------------------------------

    
    public class Preposition
    {
        /// <summary>Null process reference.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? NilProcess { get; set; }

        /// <summary>Null item reference.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? NilItem { get; set; }

        /// <summary>Process location reference.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AtProcess { get; set; }

        /// <summary>Item location reference.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AtItem { get; set; }

        /// <summary>Source process reference.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FromProcess { get; set; }

        /// <summary>Source item reference.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FromItem { get; set; }

        /// <summary>Target process reference.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ToProcess { get; set; }

        /// <summary>Target item reference.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ToItem { get; set; }

        /// <summary>Associated process reference.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? WithProcess { get; set; }

        /// <summary>Associated item reference.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? WithItem { get; set; }
    }
}
