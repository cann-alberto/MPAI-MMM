using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public class SimpleTime
    {
        [Required]
        [RegularExpression(@"^OSD-STM-[0-9]{1,2}[.][0-9]{1,2}$")]
        public string Header { get; set; } = null!;

        /// <summary>
        /// Identifier of the M-Instance associated with this SimpleTime.
        /// </summary>
        public string? MInstanceID { get; set; }

        /// <summary>
        /// Unique identifier for this SimpleTime object.
        /// </summary>
        [Required]
        public string SimpleTimeID { get; set; } = null!;

        /// <summary>
        /// List of time segments with flags and absolute ± TimeUnit accuracy.
        /// At least one segment required.
        /// </summary>
        [Required]
        [MinLength(1)]
        public List<SimpleTimeSegment> SimpleTimeData { get; set; } = null!;

        /// <summary>
        /// Rights associated with this SimpleTime object.
        /// At least one element required if present (minItems: 1).
        /// Each entry is either a full Right object or a RightID string reference.
        /// References the already-defined RightsEntry class.
        /// </summary>
        [MinLength(1)]
        public List<RightsEntry>? Rights { get; set; }

        /// <summary>
        /// DataExchangeMetadata associated with this SimpleTime.
        /// References the already-defined DataExchangeMetadata class.
        /// </summary>
        public DataExchangeMetadata? DataExchangeMetadata { get; set; }

        /// <summary>
        /// Trace associated with this SimpleTime.
        /// References the already-defined Trace class.
        /// </summary>
        public Trace? Trace { get; set; }

        [MaxLength(2048)]
        public string? DescrMetadata { get; set; }
    }


    // ---------------------------------------------------------------------------
    // SimpleTimeSegment — items of SimpleTimeData array
    // ---------------------------------------------------------------------------

    /// <summary>
    /// A single time segment with accuracy parameters and decoded flag fields.
    ///
    /// Conditional validation rules (allOf / if-then from schema):
    ///   - If AccuracyMode == "single"   → AccuracyPlusMinus is required.
    ///   - If AccuracyMode == "separate" → AccuracyStartPlusMinus and
    ///                                     AccuracyEndPlusMinus are both required.
    /// These conditions cannot be expressed via data annotations alone;
    /// enforce them in the service/validation layer or via IValidatableObject.
    /// </summary>
    public class SimpleTimeSegment : IValidatableObject
    {
        /// <summary>
        /// Raw flags byte encoding TimeUnit (bits 1–2), TimeType (bit 0)
        /// and Reserved (bits 3–7).
        /// Valid range: 0–255.
        /// </summary>
        [Required]
        [Range(0, 255)]
        public int FlagsByte { get; set; }

        /// <summary>
        /// Start of the time segment as an offset in TimeUnit from the
        /// epoch implied by TimeType.
        /// </summary>
        [Required]
        public double StartTime { get; set; }

        /// <summary>
        /// End of the time segment as an offset in TimeUnit from the
        /// epoch implied by TimeType.
        /// </summary>
        [Required]
        public double EndTime { get; set; }

        /// <summary>
        /// Accuracy mode applied to this segment.
        /// "single"   → one ± applies to both StartTime and EndTime.
        /// "separate" → distinct ± values for StartTime and EndTime.
        /// Default: "single".
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SimpleTimeAccuracyMode AccuracyMode { get; set; } = SimpleTimeAccuracyMode.Single;

        /// <summary>
        /// Required when AccuracyMode == "single".
        /// Absolute ± tolerance (in TimeUnit) applying to both StartTime and EndTime.
        /// Must be >= 0.
        /// </summary>
        [Range(0, double.MaxValue)]
        public double? AccuracyPlusMinus { get; set; }

        /// <summary>
        /// Required when AccuracyMode == "separate".
        /// Absolute ± tolerance (in TimeUnit) for StartTime only.
        /// Must be >= 0.
        /// </summary>
        [Range(0, double.MaxValue)]
        public double? AccuracyStartPlusMinus { get; set; }

        /// <summary>
        /// Required when AccuracyMode == "separate".
        /// Absolute ± tolerance (in TimeUnit) for EndTime only.
        /// Must be >= 0.
        /// </summary>
        [Range(0, double.MaxValue)]
        public double? AccuracyEndPlusMinus { get; set; }

        /// <summary>
        /// Decoded from FlagsByte bit 0.
        /// false = Relative (epoch 0000/00/00T00:00).
        /// true  = Absolute (epoch 1970/01/01T00:00).
        /// </summary>
        public bool? TimeType { get; set; }

        /// <summary>
        /// Decoded from FlagsByte bits 1–2.
        /// Allowed values: "00"=sec, "01"=ms, "10"=us, "11"=ns.
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TimeUnitCode? TimeUnit { get; set; }

        /// <summary>
        /// Decoded from FlagsByte bits 3–7 (5 reserved bits).
        /// Valid range: 0–31.
        /// </summary>
        [Range(0, 31)]
        public int? Reserved { get; set; }


        // ---------------------------------------------------------------------------
        // IValidatableObject — enforces the allOf / if-then rules from the schema
        // ---------------------------------------------------------------------------

        /// <summary>
        /// Validates the conditional accuracy requirements:
        ///   - AccuracyMode == single   → AccuracyPlusMinus must be set.
        ///   - AccuracyMode == separate → AccuracyStartPlusMinus and
        ///                                AccuracyEndPlusMinus must both be set.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (AccuracyMode == SimpleTimeAccuracyMode.Single)
            {
                if (AccuracyPlusMinus is null)
                    yield return new ValidationResult(
                        "AccuracyPlusMinus is required when AccuracyMode is 'single'.",
                        new[] { nameof(AccuracyPlusMinus) });
            }
            else if (AccuracyMode == SimpleTimeAccuracyMode.Separate)
            {
                if (AccuracyStartPlusMinus is null)
                    yield return new ValidationResult(
                        "AccuracyStartPlusMinus is required when AccuracyMode is 'separate'.",
                        new[] { nameof(AccuracyStartPlusMinus) });

                if (AccuracyEndPlusMinus is null)
                    yield return new ValidationResult(
                        "AccuracyEndPlusMinus is required when AccuracyMode is 'separate'.",
                        new[] { nameof(AccuracyEndPlusMinus) });
            }
        }
    }

    public enum SimpleTimeAccuracyMode
    {
        [JsonPropertyName("single")] Single,
        [JsonPropertyName("separate")] Separate
    }
}
