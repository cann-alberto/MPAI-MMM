using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public class Time
    {
        [Required]
        [RegularExpression(@"^OSD-TIM-[0-9]{1,2}[.][0-9]{1,2}$")]
        public string Header { get; set; } = null!;

        public string? MInstanceID { get; set; }

        [Required]
        public string TimeID { get; set; } = null!;

        [Required]
        public string Data { get; set; } = null!;

        public TimeQualifier? Qualifier { get; set; }

        public TimeAccuracy? Accuracy { get; set; }

        public DataExchangeMetadata? DataExchangeMetadata { get; set; }

        public Trace? Trace { get; set; }

        [MaxLength(2048)]
        public string? DescrMetadata { get; set; }
    }


    // ---------------------------------------------------------------------------
    // Accuracy (inline object definition)
    // ---------------------------------------------------------------------------

    public class TimeAccuracy
    {
        [Required]
        public string Mode { get; set; } = "numeric";

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TimeAccuracySingle? Single { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TimeAccuracySeparate? Separate { get; set; }
    }

    public class TimeAccuracySingle
    {
        [Required]
        [Range(0, double.MaxValue)]
        public double PlusMinus { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TimeUnitCode TimeUnit { get; set; }
    }


    public class TimeAccuracySeparate
    {

        [Required]
        [Range(0, double.MaxValue)]
        public double StartPlusMinus { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double EndPlusMinus { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TimeUnitCode TimeUnit { get; set; }
    }

    public enum TimeUnitCode
    {
        [JsonPropertyName("00")] Code00,
        [JsonPropertyName("01")] Code01,
        [JsonPropertyName("10")] Code10,
        [JsonPropertyName("11")] Code11
    }
}
