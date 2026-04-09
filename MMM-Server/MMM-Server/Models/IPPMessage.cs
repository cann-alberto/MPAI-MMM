using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public class IPPMessage
    {
        [RegularExpression(@"^MMM-IPP-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string? Header { get; set; }

        public string? MInstanceID { get; set; }

        public string? MEnvironmentID { get; set; }

        public string? IPPMessageID { get; set; }

        public string? PreviousMessageID { get; set; }

        public List<IPPMessageProcessID>? ProcessID { get; set; }

        public List<IPPMessagePAIDOrPA>? PAIDOrPA { get; set; }

        public string? ResolutionServiceID { get; set; }

        public string? Status { get; set; }

        [MinLength(1)]
        public List<RightsEntry>? Rights { get; set; }

        public DataExchangeMetadata? DataExchangeMetadata { get; set; }

        public Trace? Trace { get; set; }

        [MaxLength(2048)]
        public string? DescrMetadata { get; set; }
    }


    // ---------------------------------------------------------------------------
    // ProcessID entry (oneOf: SourceProcessID | DesimationProcessID)
    // ---------------------------------------------------------------------------

    public class IPPMessageProcessID
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SourceProcessID { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("DesimationProcessID")]
        public int? DesimationProcessID { get; set; }
    }


    // ---------------------------------------------------------------------------
    // PAIDOrPA entry (oneOf: ProcessAction | ProcessActionID)
    // ---------------------------------------------------------------------------

    public class IPPMessagePAIDOrPA
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ProcessAction? ProcessAction { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ProcessActionID { get; set; }
    }
}
