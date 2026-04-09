using System.ComponentModel.DataAnnotations;

namespace MMM_Server.Models
{
    public class MLModelManifest
    {
        [Required]
        [RegularExpression(@"^AIF-MLM-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string Header { get; set; } = null!;

        public string? MInstanceID { get; set; }

        [Required]
        public string MLModelManifestID { get; set; } = null!;

        public string? MLModelFunction { get; set; }

        public List<string>? TrainingDataSetIDs { get; set; }

        public MLModelDataTypes? MLModelInputDataTypes { get; set; }

        public MLModelDataTypes? MLModelOutputDataTypes { get; set; }

        public DataExchangeMetadata? DataExchangeMetadata { get; set; }

        public Trace? Trace { get; set; }

        [MaxLength(2048)]
        public string? DescrMetadata { get; set; }
    }


    // ---------------------------------------------------------------------------
    // MLModelDataTypes — shared by both Input and Output descriptors
    // ---------------------------------------------------------------------------

    public class MLModelDataTypes
    {
        [Required]
        public MLModelDataType DataType { get; set; } = null!;
    }

    public class MLModelDataType
    {
        [Required]
        [RegularExpression(@"^[A-Z]{3}-[A-Z]{3}-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string Acronym { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;
    }
}
