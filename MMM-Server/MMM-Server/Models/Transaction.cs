
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MMM_Server.Models;

public class Transaction
{
    public string Header { get; set; } = null!;
    public string MInstanceID { get; set; } = null!;
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? TransactionID { get; set; }        
    public TransactionData TransactionData { get; set; } = null!;
    public string DescrMetadata { get; set; } = null!;

}

public class TransactionData
{
    public string AssetID { get; set; } = null;
    public string TransactionTime {  get; set; } = null!;
    public SenderData? SenderData { get; set; } = null!;
    public ReceiverData? ReceiverData { get; set; } = null;
    public ServiceProviderData? ServiceProviderData { get; set; } = null;
}

public class SenderData
{
    public string SenderID { get; set; } = null;
    public string RToSValue { get; set; } = null!;
    public string SToSPValue { get; set; } = null!;
    public string SenderRightsID { get; set; } = null!;
    public string SenderWalletID { get; set; } = null!;

}

public class ReceiverData
{
    public string ReceiverID { get; set; } = null;
    public string RToSPValue { get; set; } = null!;
    public string ReceiverRightsID { get; set; } = null!;
    public string ReceiverWalletID { get; set; } = null!;
}

public class ServiceProviderData
{
    public string ServiceProviderID { get; set; } = null!;
    public string ServiceProviderWalletID { get; set; } = null!;
}

