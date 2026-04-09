using System.ComponentModel.DataAnnotations;

namespace MMM_Server.Models
{
    public class Value
    {
        [RegularExpression(@"^MMM-VAL-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string? Header { get; set; }

        public string? MInstanceID { get; set; }

        public string? MEnvironmentID { get; set; }

        public string? ValueID { get; set; }

        public double? Amount { get; set; }

        public CurrencyObject? Currency { get; set; }

        [MinLength(1)]
        public List<RightsEntry>? Rights { get; set; }

        public DataExchangeMetadata? DataExchangeMetadata { get; set; }

        public Trace? Trace { get; set; }

        [MaxLength(2048)]
        public string? DescrMetadata { get; set; }
    }
}
