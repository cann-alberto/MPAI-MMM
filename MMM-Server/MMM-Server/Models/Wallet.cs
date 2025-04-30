using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace MMM_Server.Models
{
    public class Wallet
    {        
        [RegularExpression(@"^MMM-WAL-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: MMM-WAL-V<digit(s)>.<digit(s)>")]
        public string Header { get; set; } = null!; // Wallet Header
        
        public string MInstanceID { get; set; } = null!; // Identifier of M-Instance.
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? WalletID { get; set; } // Identifier of Wallet.

        public WalletData? WalletData { get; set; } = null;
             
        public string? DescrMetadata { get; set; } = null!; // Descriptive Metadata
    }

    public class WalletData 
    {        
        public List<string> ValueIDs { get; set; } = null; // ID of Values for Currencies.
        public List<string> TransactionIDs { get; set; } = null; // ID of Transactions affecting a Value.
    }

    public class Value
    {
        [RegularExpression(@"^MMM-VAL-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: MMM-VAL-V<digit(s)>.<digit(s)>")]  
        public string Header { get; set; } = null!; // Value Header
        public string MInstanceID { get; set; } = null!; // Identifier of M-Instance.
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string? ValueID { get; set; } // Identifier of Value.
        
        public ValueData? ValueData { get; set; } 

        public string? DescrMetadata { get; set; } = null!; // Descriptive Metadata

    }

    public class ValueData
    {
        public string Amount { get; set; } = null!;
        public Currency Currency { get; set; } = null!;
    }

    public class Currency
    {
        [RegularExpression(@"^MMM-CUR-V[0-9]{1,2}[.][0-9]{", ErrorMessage = "Header must match the pattern: MMM-CUR-V<digit(s)>.<digit(s)>")]
        public string Header { get; set; } = null!; // Currency Header
        public string? MInstanceID { get; set; } = null!; // Identifier of M-Instance
        [BsonSerializer(typeof(GenericBsonSerializer))]
        public object? CurrencyQualifier { get; set; } = null!;
        public string? DescrMetadata { get; set; } = null!; // Descriptive Metadata
    }

}
