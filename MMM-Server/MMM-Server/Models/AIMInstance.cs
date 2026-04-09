using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public class AIMInstance
    {
        [Required]
        [RegularExpression(@"^OSD-AIN-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string Header { get; set; } = null!;

        [Required]
        public string AIMInstanceID { get; set; } = null!;

        public List<AIMInstanceAttribute>? AIMInstanceAttributes { get; set; }

        public DataExchangeMetadata? DataExchangeMetadata { get; set; }

        public Trace? Trace { get; set; }

        [MaxLength(2048)]
        public string? DescrMetadata { get; set; }
    }


    // ---------------------------------------------------------------------------
    // AIMInstanceAttribute (oneOf — exactly one property populated per entry)
    // ---------------------------------------------------------------------------

   
    public class AIMInstanceAttribute
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [RegularExpression(@"^[A-Z]{3}-[A-Z]{3}-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string? AIMType { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AIMID { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImplementerAIMID { get; set; }
    }
}
