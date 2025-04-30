using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using System.Text.Json;

namespace MMM_Server.Models;

/// <summary>
/// The Item class represents a key-value pair, with support for various data types for Value.
/// </summary>
public class Item
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ItemID { get; set; } // Identifier of the Basic Object.
    public string ItemType { get; set; }

    [BsonSerializer(typeof(GenericBsonSerializer))]  
    public object ItemContent { get; set; }  
}

public class GenericBsonSerializer : IBsonSerializer<object>
{
    public Type ValueType => typeof(object);

    public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var bsonValue = BsonValueSerializer.Instance.Deserialize(context, args);

        return bsonValue switch
        {
            BsonNull => null!,
            BsonString bsonString => bsonString.AsString,
            BsonInt32 bsonInt => bsonInt.AsInt32,
            BsonInt64 bsonLong => bsonLong.AsInt64,
            BsonDouble bsonDouble => bsonDouble.AsDouble,
            BsonBoolean bsonBool => bsonBool.AsBoolean,
            BsonDocument bsonDoc => BsonSerializer.Deserialize<object>(bsonDoc),
            _ => bsonValue
        };
    }

    public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
    {
        if (value is JsonElement jsonElement)
        {
            // Convertiamo JsonElement in un oggetto C# per la serializzazione
            value = JsonElementToObject(jsonElement);
        }

        BsonValue bsonValue = BsonValue.Create(value);
        BsonValueSerializer.Instance.Serialize(context, args, bsonValue);
    }

    private object JsonElementToObject(JsonElement element)
    {
        return element.ValueKind switch
        {
            JsonValueKind.String => element.GetString()!,
            JsonValueKind.Number => element.TryGetInt64(out long l) ? l : element.GetDouble(),
            JsonValueKind.True => true,
            JsonValueKind.False => false,
            JsonValueKind.Object => BsonDocument.Parse(element.GetRawText()),
            JsonValueKind.Array => element.EnumerateArray().Select(JsonElementToObject).ToArray(),
            _ => null!
        };
    }
}