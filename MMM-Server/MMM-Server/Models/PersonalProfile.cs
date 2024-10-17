using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MMM_Server.Models
{
    public class PersonalProfile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Header { get; set; } = null!;

        public string MInstanceID { get; set; } = null!;

        public string HumanID { get; set; } = null!;

        public string PersonalProfileID { get; set; } = null!;

        public PersonalProfileData PersonalProfileData { get; set; } = null!;

        public string DescrMetadata { get; set; } = null!;

    }
    
}
