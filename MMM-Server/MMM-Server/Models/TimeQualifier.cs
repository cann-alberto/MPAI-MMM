using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public class TimeQualifier
    {
        [Required]
        [RegularExpression(@"^TFA-TIQ-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string Header { get; set; } = null!;

        [Required]
        public string TimeQualifierID { get; set; } = null!;

        [Required]
        public object SubType { get; set; } = new();

        [Required]
        public TimeQualifierFormat Format { get; set; } = null!;

        public TimeQualifierAttributes? Attributes { get; set; }

        public DataExchangeMetadata? DataExchangeMetadata { get; set; }

        [Required]
        public Trace Trace { get; set; } = null!;

        [MaxLength(2048)]
        public string? DescrMetadata { get; set; }
    }


    // ---------------------------------------------------------------------------
    // Format (inline object definition)
    // ---------------------------------------------------------------------------

    public class TimeQualifierFormat
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SimpleTime? MPAIFormat { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TimeFormats? OtherFormats { get; set; }
    }


    // ---------------------------------------------------------------------------
    // Attributes (inline object definition)
    // ---------------------------------------------------------------------------

    public class TimeQualifierAttributes
    {
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TimeKind Kind { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public IntervalFormType? IntervalForm { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Time? Recurrence { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<TimeException>? Exceptions { get; set; }
    }

    public class TimeException
    {
        [Required]
        public Time Exception { get; set; } = null!;
    }

    public enum TimeKind
    {
        [JsonPropertyName("point")] Point,
        [JsonPropertyName("interval")] Interval,
        [JsonPropertyName("duration")] Duration
    }

    public enum IntervalFormType
    {
        [JsonPropertyName("startEnd")] StartEnd,
        [JsonPropertyName("startDuration")] StartDuration,
        [JsonPropertyName("durationEnd")] DurationEnd
    }
}
