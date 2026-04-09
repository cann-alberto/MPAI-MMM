using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public class DataExchangeMetadata
    {
        public string? DataExchangeMetadataID { get; set; }

        [Required]
        public string DataID { get; set; } = null!;

        [RegularExpression(@"^[A-Z]{3}-[A-Z]{3}-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string? DataType { get; set; }

        [Required]
        public ProcessInstance Source { get; set; } = null!;

        public List<DataAuthorisation>? Authorisations { get; set; }

        public object? Legality { get; set; }

        public ProcessInstance? Privacy { get; set; }

        public Security? Security { get; set; }

        [Range(0.0, 1.0)]
        public double? Confidence { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DataExchangeMetadata? NestedDataExchangeMetadata { get; set; }

        public Trace? Trace { get; set; }

        [MaxLength(2048)]
        public string? DescrMetadata { get; set; }
    }


    // ---------------------------------------------------------------------------
    // Authorisations entry (inline object definition)
    // ---------------------------------------------------------------------------

    public class DataAuthorisation
    {
        [Required]
        public ProcessInstance AIMOrProcess { get; set; } = null!;

        [Required]
        [MinLength(1)]
        public List<AuthorisedDataEntry> Data { get; set; } = null!;
    }

    public class AuthorisedDataEntry
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [RegularExpression(@"^[A-Z]{3}-[A-Z]{3}-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string? DataType { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DataID { get; set; }
    }
}
