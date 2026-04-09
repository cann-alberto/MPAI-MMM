using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public class ActivityData
    {
        [RegularExpression(@"^MMM-ACD-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string? Header { get; set; }

        public string? MInstanceID { get; set; }

        public string? MIEnvironment { get; set; }

        public string? ActivityDataID { get; set; }

        public List<ActivityDataSimpleItem>? ActivityData1 { get; set; }

        public List<ActivityDataEntry>? ActivityDataItems { get; set; }

        [MinLength(1)]
        public List<RightsEntry>? Rights { get; set; }

        public DataExchangeMetadata? DataExchangeMetadata { get; set; }

        public Trace? Trace { get; set; }

        [MaxLength(2048)]
        public string? DescrMetadata { get; set; }
    }


    // ---------------------------------------------------------------------------
    // ActivityData1 item — simplified ID-only reference
    // ---------------------------------------------------------------------------

    public class ActivityDataSimpleItem
    {
        [JsonPropertyName("IPPMessagenID")]
        public string? IPPMessagenID { get; set; }
    }


    // ---------------------------------------------------------------------------
    // ActivityDataEntry — oneOf: IPPMessage | ID-only reference
    // ---------------------------------------------------------------------------

    public class ActivityDataEntry
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IPPMessage? IPPMessage { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("IPPMessagenID")]
        public string? IPPMessagenID { get; set; }
    }
}
