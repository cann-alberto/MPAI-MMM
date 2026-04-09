using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public class Capabilities
    {
        [Required]
        [RegularExpression(@"^MMM-CPB-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string Header { get; set; } = null!;

        [Required]
        public string MInstanceID { get; set; } = null!;

        [Required]
        public string MEnvironmentID { get; set; } = null!;

        [Required]
        public string CapabilitiesID { get; set; } = null!;

        [Required]
        public string WalletID { get; set; } = null!;

        [Required]
        public CapabilitiesItem ItemCapabilities { get; set; } = null!;

        [Required]
        public CapabilitiesMInstance MInstanceCapabilities { get; set; } = null!;

        [Required]
        public CapabilitiesProcess ProcessCapabilities { get; set; } = null!;

        [MinLength(1)]
        public List<RightsEntry>? Rights { get; set; }

        [Required]
        public DataExchangeMetadata DataExchangeMetadata { get; set; } = null!;

        [Required]
        public Trace Trace { get; set; } = null!;

        
        [Required]
        [MaxLength(2048)]
        public string DescrMetadata { get; set; } = null!;
    }


    // ---------------------------------------------------------------------------
    // ItemCapabilities ($defs/ItemCapabilities)
    // ---------------------------------------------------------------------------

    public class CapabilitiesItem
    {
        [Required]
        public List<string> Processes { get; set; } = null!;

        [Required]
        public List<AnyProcessAction> ProcessActionsByType { get; set; } = null!;

        [Required]
        public List<string> ItemMetadata { get; set; } = null!;
    }


    // ---------------------------------------------------------------------------
    // MInstanceCapabilities ($defs/MInstanceCapabilities)
    // ---------------------------------------------------------------------------

    public class CapabilitiesMInstance
    {
        [Required]
        public CoordinateTypes CoordinateType { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MInstanceProfile Profile { get; set; }

        [Required]
        public List<string> Actions { get; set; } = null!;

        [Required]
        public List<AnyItem> Items { get; set; } = null!;

        [Required]
        public List<AnyQualifier> Qualifiers { get; set; } = null!;

        [Required]
        public List<string> PMetadata { get; set; } = null!;

        [Required]
        public List<string> IMetadata { get; set; } = null!;
    }

    public enum MInstanceProfile
    {
        [JsonPropertyName("Baseline")] Baseline,
        [JsonPropertyName("Finance")] Finance,
        [JsonPropertyName("Management")] Management,
        [JsonPropertyName("High")] High
    }


    // ---------------------------------------------------------------------------
    // ProcessCapabilities ($defs/ProcessCapabilities)
    // ---------------------------------------------------------------------------

    public class CapabilitiesProcess
    {
        [Required]
        public string HumanID { get; set; } = null!;

        [Required]
        public List<string> SupportedApps { get; set; } = null!;

        [Required]
        public List<string> Actions { get; set; } = null!;

        [Required]
        public List<string> ProcessMetadata { get; set; } = null!;

        [Required]
        public List<AnyItem> Items { get; set; } = null!;

        [Required]
        public List<string> ItemMetadata { get; set; } = null!;

        [Required]
        public List<AnyQualifier> ItemQualifiers { get; set; } = null!;

        [Required]
        public Dictionary<string, object> TransactionInfo { get; set; } = null!;

        [Required]
        public string CapabilityChange { get; set; } = null!;

        [Required]
        public List<string> MInstances { get; set; } = null!;
    }
}
