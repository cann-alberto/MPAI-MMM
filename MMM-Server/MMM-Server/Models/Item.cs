using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    /// <summary>   
    /// Conditional rule (allOf / if-then from schema):
    ///   If ProcessType == "User" → HumanID may be present.
    ///   This is an additive rule (no required fields added), so it is
    ///   documented here and can be enforced in the service layer if needed.
    /// </summary>
    public class Item : IValidatableObject
    {
        [RegularExpression(@"^MMM-ITM-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string? Header { get; set; }

        [BsonId]
        [Required]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ItemID { get; set; } = null!;

        public string? SourceItemID { get; set; }

        public string? ItemData { get; set; }

        public AnyQualifier? ItemQualifier { get; set; }

        public ItemCapabilities? ICapabilities { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ItemStatus? ItemStatus { get; set; }

        public string? ProcessType { get; set; }

        public string? HumanID { get; set; }

        [MinLength(1)]
        public List<RightsEntry>? Rights { get; set; }

        public DataExchangeMetadata? DataExchangeMetadata { get; set; }

        public Trace? Trace { get; set; }

        [MaxLength(2048)]
        public string? DescrMetadata { get; set; }


        // ---------------------------------------------------------------------------
        // IValidatableObject — enforces the allOf / if-then rule from the schema
        // ---------------------------------------------------------------------------

        /// <summary>
        /// Validates that HumanID is only populated when ProcessType is "User".
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (HumanID is not null && ProcessType != "User")
                yield return new ValidationResult(
                    "HumanID may only be set when ProcessType is \"User\".",
                    new[] { nameof(HumanID) });
        }
    }


    // ---------------------------------------------------------------------------
    // ItemStatus enum
    // ---------------------------------------------------------------------------

    public enum ItemStatus
    {
        [JsonPropertyName("Model")] Model,
        [JsonPropertyName("Final")] Final
    }


    // ---------------------------------------------------------------------------
    // ItemCapabilities — oneOf: Capabilities object | string ID
    // ---------------------------------------------------------------------------

    public class ItemCapabilities
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Capabilities? Capabilities { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CapabilitiesID { get; set; }
    }
}
