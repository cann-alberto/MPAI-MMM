using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public class ProcessInstance
    {
        [Required]
        [RegularExpression(@"^AIF-PRI-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string Header { get; set; } = null!;

        [Required]
        public string ProcessInstanceID { get; set; } = null!;

        public List<ProcessAttribute>? ProcessAttributes { get; set; }

        public MLModelQualifier? MLModelQualifier { get; set; }

        public Trace? Trace { get; set; }

        [MaxLength(2048)]
        public string? DescrMetadata { get; set; }
    }


    // ---------------------------------------------------------------------------
    // ProcessAttribute (oneOf — exactly one property populated per entry)
    // ---------------------------------------------------------------------------

    public class ProcessAttribute
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [RegularExpression(@"^[A-Z]{3}-[A-Z]{3}-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string? AIMType { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AIMID { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImplementerAIMID { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ProcessType { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ProcessID { get; set; }
    }
}
