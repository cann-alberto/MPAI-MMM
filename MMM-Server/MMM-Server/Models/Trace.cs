using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public class Trace
    {
        [Required]
        [RegularExpression(@"^OSD-TRC-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string Header { get; set; } = null!;

        public string? MInstance { get; set; }

        public string? UEnvironment { get; set; }

        [Required]
        public string TraceID { get; set; } = null!;

        public List<TraceSourceEntry>? Source { get; set; }

        public Time? Time { get; set; }

        [MaxLength(2048)]
        public string? DescrMetadata { get; set; }
    }


    // ---------------------------------------------------------------------------
    // TraceSourceEntry (oneOf: AIMInstance | ProcessID)
    // ---------------------------------------------------------------------------

    public class TraceSourceEntry
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AIMInstance? AIMInstance { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ProcessID { get; set; }
    }
}
