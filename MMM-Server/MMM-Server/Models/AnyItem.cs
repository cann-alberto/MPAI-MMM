using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public class AnyItem
    {
        [Required]
        public string ItemName { get; set; } = null!;

        [Required]
        [MinLength(1)]
        [MaxLength(1)]
        public List<AnyItemValueOrRef> ItemValueOrRef { get; set; } = null!;

        [Required]
        public string MInstanceID { get; set; } = null!;

        [Required]
        public string MEnvironmentID { get; set; } = null!;

        public DataExchangeMetadata? DataExchangeMetadata { get; set; }

        [Required]
        public Trace Trace { get; set; } = null!;

        [Required]
        [MaxLength(2048)]
        public string DescrMetadata { get; set; } = null!;
    }


    // ---------------------------------------------------------------------------
    // AnyItemValueOrRef — oneOf: free-form object | URI string
    // ---------------------------------------------------------------------------

    public class AnyItemValueOrRef : IValidatableObject
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, object>? ObjectValue { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [Url]
        public string? UriRef { get; set; }


        // ---------------------------------------------------------------------------
        // IValidatableObject — enforces the oneOf constraint
        // ---------------------------------------------------------------------------

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int populated = (ObjectValue is not null ? 1 : 0)
                          + (UriRef is not null ? 1 : 0);

            if (populated != 1)
                yield return new ValidationResult(
                    "Exactly one of ObjectValue or UriRef must be populated (oneOf).",
                    new[] { nameof(ObjectValue), nameof(UriRef) });
        }
    }
}