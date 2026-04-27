using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MMM_Server.Models;

public class Asset : IValidatableObject
{
    [RegularExpression(@"^MMM-ASS-V[0-9]{1,2}[.][0-9]{1,2}$")]
    public string? Header { get; set; }

    public string? MInstanceID { get; set; }

    public string? MEnvironmentID { get; set; }

    public string? AssetID { get; set; }

    public string? SourceItemID { get; set; }

    public Time? AssetDate { get; set; }

    public Capabilities? Capabilities { get; set; }

    /// <summary>
    /// Provenance descriptor for this Asset.
    /// ⚠️ EXTERNAL REFERENCE: Provenance
    /// "$ref": "https://schemas.mpai.community/MMM4/V2.2/data/Provenance.json"
    /// </summary>
    public Provenance? Provenance { get; set; }

    /// <summary>
    /// Market class of this Asset.
    /// ⚠️ EXTERNAL REFERENCE: MarketClasses
    /// "$ref": "https://schemas.mpai.community/MMM4/V2.2/data/MarketClasses.json"
    /// When set to "MC-Service", ServicePricingModel becomes required.
    /// </summary>
    public MarketClasses? MarketClass { get; set; }

    /// <summary>
    /// List of value metadata identifiers associated with this Asset.
    /// ⚠️ EXTERNAL REFERENCE: ValueMetadataIDs
    /// "$ref": "https://schemas.mpai.community/MMM4/V2.2/data/ValueMetadataIDs.json"
    /// </summary>
    public List<ValueMetadataIDs>? ValueMetadata { get; set; }

    /// <summary>
    /// Currency identifier for this Asset.
    /// Either a RealCurrencies or VirtualCurrencies value (oneOf).
    /// References the already-defined RealCurrencies and VirtualCurrencies enums.
    /// </summary>
    public AssetCurrencyID? CurrencyID { get; set; }

    /// <summary>
    /// Service pricing model for this Asset.
    /// Required when MarketClass is "MC-Service" (allOf / if-then rule).
    /// ⚠️ EXTERNAL REFERENCE: ServicePricingModel
    /// "$ref": "https://schemas.mpai.community/MMM4/V2.2/data/ServicePricingModel.json"
    /// </summary>
    public ServicePricingModel? ServicePricingModel { get; set; }

    /// <summary>
    /// Marketplace policy identifiers for this Asset.
    /// ⚠️ EXTERNAL REFERENCE: MarketplacePolicyIDs
    /// "$ref": "https://schemas.mpai.community/MMM4/V2.2/data/MarketplacePolicyIDs.json"
    /// </summary>
    public MarketplacePolicyIDs? MarketplacePolicy { get; set; }

    [MinLength(1)]
    public List<RightsEntry>? Rights { get; set; }

    public DataExchangeMetadata? DataExchangeMetadata { get; set; }

    public Trace? Trace { get; set; }

    [MaxLength(2048)]
    public string? DescrMetadata { get; set; }


    // ---------------------------------------------------------------------------
    // IValidatableObject — enforces the allOf / if-then rule from the schema
    // ---------------------------------------------------------------------------

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (MarketClass?.ToString() == "MC-Service" && ServicePricingModel is null)
            yield return new ValidationResult(
                "ServicePricingModel is required when MarketClass is \"MC-Service\".",
                new[] { nameof(ServicePricingModel) });
    }
}


// ---------------------------------------------------------------------------
// AssetCurrencyID — oneOf: RealCurrencies | VirtualCurrencies
// ---------------------------------------------------------------------------

public class AssetCurrencyID : IValidatableObject
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public RealCurrencies? RealCurrency { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public VirtualCurrencies? VirtualCurrency { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        int populated = (RealCurrency is not null ? 1 : 0)
                      + (VirtualCurrency is not null ? 1 : 0);

        if (populated != 1)
            yield return new ValidationResult(
                "Exactly one of RealCurrency or VirtualCurrency must be populated (oneOf).",
                new[] { nameof(RealCurrency), nameof(VirtualCurrency) });
    }
}
