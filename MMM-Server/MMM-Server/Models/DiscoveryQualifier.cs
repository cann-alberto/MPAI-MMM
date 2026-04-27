using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public class DiscoveryQualifier
    {
        [Required]
        [RegularExpression(@"^TFA-DVQ-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string Header { get; set; } = null!;

        [Required]
        public string DiscoveryQualifierID { get; set; } = null!;

        [Required]
        public DiscoveryQualifierFormat Format { get; set; } = null!;

        public DataExchangeMetadata? DataExchangeMetadata { get; set; }

        [Required]
        public Trace Trace { get; set; } = null!;

        [MaxLength(2048)]
        public string? DescrMetadata { get; set; }
    }


    // ---------------------------------------------------------------------------
    // Format (inline object definition)
    // ---------------------------------------------------------------------------

    public class DiscoveryQualifierFormat
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BasicDiscovery? MPAIContentFormat { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DiscoveryFormats? OtherContentFormats { get; set; }
    }
}