using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public class ThreeDModelQualifier
    {
        [Required]
        [RegularExpression(@"^TFA-3MQ-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string Header { get; set; } = null!;

        [Required]
        [JsonPropertyName("3DModelQualifierID")]
        public string ThreeDModelQualifierID { get; set; } = null!;

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ThreeDModelSubType SubType { get; set; }

        [Required]
        public ThreeDModelFormat Format { get; set; } = null!;

        public Dictionary<string, object>? Attributes { get; set; }

        public DataExchangeMetadata? DataExchangeMetadata { get; set; }

        public Trace? Trace { get; set; }

        [MaxLength(2048)]
        public string? DescrMetadata { get; set; }
    }


    // ---------------------------------------------------------------------------
    // SubType enum
    // ---------------------------------------------------------------------------

    public enum ThreeDModelSubType
    {
        [JsonPropertyName("Real")] Real,
        [JsonPropertyName("Virtual")] Virtual,
        [JsonPropertyName("Hybrid")] Hybrid
    }


    // ---------------------------------------------------------------------------
    // Format (inline object definition)
    // ---------------------------------------------------------------------------

    public class ThreeDModelFormat
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ThreeDModelContentFormats? ContentFormat { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ThreeDModelTransportFormats? TransportFormat { get; set; }
    }
}