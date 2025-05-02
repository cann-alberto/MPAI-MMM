
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace MMM_Server.Models;

public class Transaction
{
    [RegularExpression(@"MMM-TRA-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: MMM-TRA-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!; // Transaction Header
    public string? MInstanceID { get; set; } = null!; // Identifier of M-Instance.
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? TransactionID { get; set; } // Identifier of Transaction.
    public TransactionData TransactionData { get; set; } = null!; // Set of Data related to Transaction
    public string? DescrMetadata { get; set; } = null!; // Any description of the Transaction.

}

public class TransactionData
{
    public string? AssetID { get; set; } = null; // The ID of the Asset the Transaction refers to.
    public Time? TransactionTime {  get; set; } = null!; // Time the Transaction is performed.
    public SenderData? SenderData { get; set; } = null!; // Sender dataset.
    public ReceiverData? ReceiverData { get; set; } = null; // Receiver dataset.
    public ServiceProviderData? ServiceProviderData { get; set; } = null; // Service Provider’s dataset.
}

public class SenderData
{
    public string SenderID { get; set; } = null;    
    public string? SToSPValue { get; set; } = null!;
    public Value? SenderRightsID { get; set; } = null!;
    public string? SenderWalletID { get; set; } = null!;

}

public class ReceiverData
{
    public string ReceiverID { get; set; } = null;
    public string? RToSPValue { get; set; } = null!;
    public string? ReceiverRightsID { get; set; } = null!;
    public string? ReceiverWalletID { get; set; } = null!;
}

public class ServiceProviderData
{
    public string? ServiceProviderID { get; set; } = null!;
    public string? ServiceProviderWalletID { get; set; } = null!;
}

