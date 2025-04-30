using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using System.Text.Json;


namespace MMM_Server.Models
{
    /// <summary>
    /// https://mpai.community/standards/mpai-mmm/tec/v2-0/process-actions/#_Toc194122748
    /// </summary>
    public class ProcessAction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ProcessActionID { get; set; }
        public string? Time{ get; set; } = null!;
        public string? Action { get; set; } = null!;
        public string? SProcess{ get; set; } = null!;
        public List<Complement>? SComplements { get; set; } = null!;
        public string? DProcess { get; set; } = null!;
        public List<Complement>? DComplements { get; set; } = null!;
        public string? ErrorMessage { get; set; } = null!;
    }


    /// <summary>
    /// The Complement class represents additional data associated with a process.
    /// Each complement consists of a key, a value type, and a value.
    /// </summary>
    public class Complement
    {
        public string Key { get; set; } = null!;

        public string ValueType { get; set; } = null!;

        // Custom serializer for the Value property to handle different data types.

        [BsonSerializer(typeof(GenericBsonSerializer))]
        public object? Value { get; set; }
    }

    
}
