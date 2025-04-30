using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace MMM_Server.Models;


public class MObject
{
    [RegularExpression(@"^PAF-OBJ-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: PAF-OBJ-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!; // Object Header

    public string? MInstanceID { get; set; } = null!; // Identifier of M-Instance

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ObjectID { get; set; } // Identifier of the Object

    public SpaceTime? ObjectSpaceTime { get; set; } = null!; // Space-Time of Object

    public int? BasicObjectCount { get; set; } // Set of Parent Objects

    [BsonElement("BasicObjects")]
    public List<BasicObject>? BasicObjects { get; set; } = null; // Set of Basic Objects.

    public int? ObjectCount { get; set; } // Set of Child Objects.

    [BsonElement("Objects")]
    public List<MObject>? Objects { get; set; } = null!; // Set of Objects.

    public List<DataAnnotation>? DataAnnotations { get; set; } = null!; //Set of Object Annotation.

    public List<string>? Rights { get; set; } = null!; // Actions that may be performed on the Object.

    public string? DescrMetadata { get; set; } = null!; // Descriptive Metadata
}

public class BasicObject
{
    [RegularExpression(@"^OSD-BOB-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: OSD-BOB-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!; // Basic Object Header

    public string? MInstanceID { get; set; } = null!; // Identifier of M-Instance

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? BasicObjectID { get; set; } // Identifier of the Basic Object.

    List<MObject>? ParentObjects { get; set; } = null!; // Set of Parent Objects.

    List<MObject>? ChildObjects { get; set; } = null!; // Set of Parent Objects.

    public SpaceTime? SpaceTime { get; set; } = null; // Space-Time of Data.

    [BsonSerializer(typeof(GenericBsonSerializer))]
    public object? Qualifier { get; set; } = null!; // Qualifier of Data.

    public List<DataAnnotation>? DataAnnotations { get; set; } = null!;

    public List<string>? Rights { get; set; } = null!; // Rights to perform Process Actions on the Object.

    public string? DescrMetadata { get; set; } = null!; // Descriptive Metadata

}

public class DataAnnotation
{
    public Annotation? Annotation { get; set; } = null!; // An Annotation.
    public SpaceTime? AnnotationSpaceTime { get; set; } // Where Annotation is attached and when it will be active.
    [BsonElement("Rights")]
    public List<string>? Rights { get; set; } = null; // Actions that may be performed on the Annotation

}

public class Annotation
{
    [RegularExpression(@"^OSD-ANN-V[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: OSD-ANN-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!;
    public string? MInstanceID { get; set; } = null!;
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? AnnotationID { get; set; }
    public string? AnnotationJSONText { get; set; } = null!;
    public string? DescrMetadata { get; set; } = null!; // Descriptive Metadata
}



