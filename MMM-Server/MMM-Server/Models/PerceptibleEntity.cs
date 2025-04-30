using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace MMM_Server.Models;

public class PerceptibleEntity
{
    [RegularExpression(@"^OSD-PCE-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: OSD-PCE-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!;

    public string? MInstanceID { get; set; } = null!;

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? PerceptibleEntityID { get; set; } = null;

    public PerceptibleEntityData? PerceptibleEntityData { get; set; } = null;

    public List<string>? RightsID { get; set; } = null;

    public string? DescrMetadata { get; set; } = null!;
}

public class PerceptibleEntityData
{
    public TextObject? TextObject { get; set; }
    public SpeechObject? SpeechObject { get; set; }
    public AudioObject? AudioObject { get; set; }
    public VisualObject? VisualObject { get; set; }
    public Model3DObject? _3DModelObject { get; set; }

    [BsonSerializer(typeof(GenericBsonSerializer))]
    public object? SpeechSceneDescriptors { get; set; }
    
    [BsonSerializer(typeof(GenericBsonSerializer))]
    public object? AudioSceneDescriptors { get; set; }

    [BsonSerializer(typeof(GenericBsonSerializer))] 
    public object? VisualSceneDescriptors { get; set; }
    
    [BsonSerializer(typeof(GenericBsonSerializer))]
    public object? AudioVisualSceneDescriptors { get; set; }
    
    [BsonSerializer(typeof(GenericBsonSerializer))]
    public object? AudioVisualEventDescriptors { get; set; }
}

public class TextObject
{
    [RegularExpression(@"^MMC-TXO-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: MMC-TXO-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!;

    public string? MInstanceID { get; set; } = null!;

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? TextObjectID { get; set; } = null;

    [BsonSerializer(typeof(GenericBsonSerializer))]    
    public object? TextObjectQualifier { get; set; } = null;

    public SpaceTime TextObjectSpaceTime { get; set; } = null!;   

    public string? DescrMetadata { get; set; } = null!;
}

public class SpeechObject
{
    [RegularExpression(@"^MMC-SPO-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: MMC-SPO-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!;

    public string? MInstanceID { get; set; } = null!;

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? SpeechObjectID { get; set; } = null;

    List<string> ParentSpeechObjectID {  get; set; } = null!;

    List<string> ChildSpeechObjects { get; set; } = null!;

    [BsonSerializer(typeof(GenericBsonSerializer))]
    public object? SpeechDataQualifier { get; set; } = null;

    public SpaceTime SpeechDataSpaceTime { get; set; } = null!;

    public List<DataAnnotation>? SpeechDataAnnotation{ get; set; } = null!; //Set of Object Annotation.

    public string? DescrMetadata { get; set; } = null!;

}

public class AudioObject
{
    [RegularExpression(@"^CAE-AUO-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: CAE-AUO-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!;

    public string? MInstanceID { get; set; } = null!;

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? AudioObjectID { get; set; } = null;

    List<string> ParentAudioObjects { get; set; } = null!;
    
    [BsonSerializer(typeof(GenericBsonSerializer))]
    public object? AudioDataQualifier { get; set; } = null;

    public SpaceTime AudioDataSpaceTime { get; set; } = null!;

    public List<DataAnnotation>? AudioDataAnnotations { get; set; } = null!; //Set of Object Annotation.

    public string? DescrMetadata { get; set; } = null!;

}

public class VisualObject
{
    [RegularExpression(@"^OSD-VIO-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: OSD-VIO-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!;

    public string? MInstanceID { get; set; } = null!;

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? VisualObjectID { get; set; } = null;

    List<string> ParentVisualObjects { get; set; } = null!;

    List<string> ChildVisualObjects { get; set; } = null!;

    [BsonSerializer(typeof(GenericBsonSerializer))]
    public object? VisualDataQualifier { get; set; } = null;

    public SpaceTime VisualDataSpaceTime { get; set; } = null!;

    public List<DataAnnotation>? VisualDataAnnotation { get; set; } = null!; //Set of Object Annotation.

    public string? DescrMetadata { get; set; } = null!;
}

public class Model3DObject
{
    [RegularExpression(@"^PAF-3MD-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: PAF-3MD-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!;

    public string? MInstanceID { get; set; } = null!;

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Model3DID { get; set; } = null;

    [BsonSerializer(typeof(GenericBsonSerializer))]
    public object? Model3DDataQualifier { get; set; } = null;

    public SpaceTime Model3DDataSpaceTime { get; set; } = null!;

    public string? DescrMetadata { get; set; } = null!;
}








