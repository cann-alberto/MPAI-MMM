using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public class AnyProcessAction
    {
        [Required]
        [RegularExpression(@"^MMM-PAC-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string Header { get; set; } = null!;

        [Required]
        public string MInstanceID { get; set; } = null!;

        [Required]
        public string ProcessActionID { get; set; } = null!;

        [Required]
        public AnyProcessActionDetail ProcessAction { get; set; } = null!;

        public DataExchangeMetadata? DataExchangeMetadata { get; set; }

        public Trace? Trace { get; set; }

        public string? DescrMetadata { get; set; }
    }


    // ---------------------------------------------------------------------------
    // AnyProcessActionDetail — nested ProcessAction object
    // ---------------------------------------------------------------------------

    public class AnyProcessActionDetail
    {
        public Time? Time { get; set; }

        public ProcessAction? Action { get; set; }

        [Required]
        public List<Preposition> RQComplements { get; set; } = null!;

        public List<Preposition>? RSComplements { get; set; }

        [Required]
        public List<AnyPAStatusEntry> PAStatus { get; set; } = null!;
    }


    // ---------------------------------------------------------------------------
    // AnyPAStatusEntry — oneOf: Ack | Error
    // ---------------------------------------------------------------------------
        
    public class AnyPAStatusEntry : IValidatableObject
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Ack { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PAErrorType? Error { get; set; }


        // ---------------------------------------------------------------------------
        // IValidatableObject — enforces the oneOf constraint
        // ---------------------------------------------------------------------------

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int populated = (Ack is not null ? 1 : 0)
                          + (Error is not null ? 1 : 0);

            if (populated != 1)
                yield return new ValidationResult(
                    "Exactly one of Ack or Error must be populated (oneOf).",
                    new[] { nameof(Ack), nameof(Error) });

            if (Ack is not null && Ack != "Ack")
                yield return new ValidationResult(
                    "Ack value must be \"Ack\" when populated.",
                    new[] { nameof(Ack) });
        }
    }
}