using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public class CurrencyQualifier
    {
        [Required]
        [RegularExpression(@"^TFA-CRQ-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string Header { get; set; } = null!;

        [Required]
        public string CurrencyQualifierID { get; set; } = null!;

        [Required]
        public CurrencyQualifierSubType SubType { get; set; } = null!;

        [Required]
        public CurrencyQualifierFormat Format { get; set; } = null!;

        public Dictionary<string, object>? Attributes { get; set; }

        public DataExchangeMetadata? DataExchangeMetadata { get; set; }

        [Required]
        public Trace Trace { get; set; } = null!;

        [MaxLength(2048)]
        public string? DescrMetadata { get; set; }
    }


    // ---------------------------------------------------------------------------
    // SubType (inline object definition)
    // ---------------------------------------------------------------------------

    public class CurrencyQualifierSubType
    {
        [MinLength(1)]
        public List<CurrencyCategory>? Categories { get; set; }
    }

    public enum CurrencyCategory
    {
        [JsonPropertyName("Real")] Real,
        [JsonPropertyName("Virtual")] Virtual
    }


    // ---------------------------------------------------------------------------
    // Format (inline object definition)
    // ---------------------------------------------------------------------------

    public class CurrencyQualifierFormat
    {
       [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RealCurrencies? RealCurrency { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VirtualCurrencies? VirtualCurrency { get; set; }
    }
}
