using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public class MLModelQualifier
    {
        [Required]
        [RegularExpression(@"^TFA-MMQ-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string Header { get; set; } = null!;

        [Required]
        public string MLModelQualifierID { get; set; } = null!;

        [Required]
        public MLModelQualifierSubType SubType { get; set; } = null!;

        [Required]
        public MLModelQualifierFormat Format { get; set; } = null!;

        public MLModelAttributes? Attributes { get; set; }
        
        public DataExchangeMetadata? DataExchangeMetadata { get; set; }

        [Required]
        public Trace Trace { get; set; } = null!;

        [MaxLength(2048)]
        public string? DescrMetadata { get; set; }
    }


    // ---------------------------------------------------------------------------
    // SubType (inline object definition)
    // ---------------------------------------------------------------------------

    public class MLModelQualifierSubType
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MLModelTypes? MLModelType { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public NNModelTypes? NNModelType { get; set; }
    }


    // ---------------------------------------------------------------------------
    // Format (inline object definition)
    // ---------------------------------------------------------------------------

    public class MLModelQualifierFormat
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public NNModelExtensions? Extension { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public NNModelFrameworks? Framework { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public NNModelExchange? Exchange { get; set; }
    }


    // ---------------------------------------------------------------------------
    // Attributes — $defs/Attributes (inline object definition)
    // ---------------------------------------------------------------------------

    public class MLModelAttributes
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MLModelManifest? MLModelManifest { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RegulationTypes? RegulationTypes { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CertificationTypes? CertificationType { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Time? Validity { get; set; }
    }
}
