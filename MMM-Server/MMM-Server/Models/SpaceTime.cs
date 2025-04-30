using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

public class SpaceTime
{
    [RegularExpression(@"^OSD-SPT-V[0-9]{1,2}[.][0-9]{1.2}$", ErrorMessage = "Header must match the pattern: OSD-SPT-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!;
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? SpaceTimeID { get; set; }
    public SpatialAttitude? SpatialAttitude1 { get; set; } = null;
    public SpatialAttitude? SpatialAttitude2 { get; set; } = null;
    public Time time { get; set; }= null!;
    public string? DescrMetadata { get; set; } = null!;
}

public class Time
{
    [RegularExpression(@"^OSD-TIM-[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: OSD-TIM<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!; // Time Header

    public string MInstanceID { get; set; } = null!; // Identifier of M-Instance    

    public TimeData TimeData { get; set; } = null !;

    public string? DescrMetadata { get; set; } = null!;
}

public class TimeData
{
    public bool TimeType { get; set; }
    public int TimeUnit { get; set; }
    public double StartTime { get; set; }
    public double EndTime { get; set; }
}

public class SpatialAttitude
{

    [RegularExpression(@"^OSD-SPT-V[0-9]{1,2}[.][0-9]{1.2}$", ErrorMessage = "Header must match the pattern: OSD-SPT-V<digit(s)>.<digit(s)>")]
    public string Header { get; set; } = null!; // Spatial Attitude Header
    public string MInstanceID { get; set; } = null!; // Identifier of M-Instance
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ObjectSpatialAttitudeID { get; set; }
    public General General { get; set; }
    [BsonElement("Position")]
    public ObjectPosition? Position { get; set; } = null!;
    [BsonElement("Orientation")]
    public ObjectOrientation? Orientation { get; set; } = null!;
    public string? DescrMetadata { get; set; } = null!;

}

public class General
{
    public CoordinateTypes CoordTypeID { get; set; }  
    public ObjectTypes ObjectType { get; set; }   
    public MediaTypes MediaType { get; set; }    
}

public enum CoordinateTypes
{
    Cartesian,
    Spherical,
    Cylindrical,
    Geodetic,
    Toroidal
}

public enum ObjectTypes
{
    DigitalHuman,
    Generic
}

public enum MediaTypes
{
    Audio,
    Visual,    
    AudioVisual,
    Haptic,
    Smell,
    LiDAR,
    RADAR,
    Ultrasound
}

public class ObjectPosition
{
    [RegularExpression(@"^OSD-OPS-[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: OSD-OPS-<digit(s)>.<digit(s)>")]
    public string Header { get; set; } // Position Header
    public string? MInstanceID { get; set; } = null!; // ID of Virtual Space Position refers to.
    public string? ObjectPositionID { get; set; } // Identifier of Object Position.
    public General General { get; set; } // Set of general data    
    public Position? Position { get; set; } 
    public VelocityOfPosition? VelocityOfPosition { get; set; }
    public AccelerationOfPosition? AccelerationOfPosition { get; set; }
    public string? DescrMetadata { get; set; } = null!;
}

public class Position 
{
    public List<double> CartPosition { get; set; }
    public List<double> CartPositionAccuracy { get; set; }
    public List<double> SpherPosition { get; set; }
    public List<double> SpherPositionAccuracy { get; set; }
}

public class VelocityOfPosition
{
    public List<double> CartVelocity { get; set; }
    public List<double> CartVelocityAccuracy { get; set; }
    public List<double> SpherVelocity { get; set; }
    public List<double> SpherVelocityAccuracy { get; set; }
}

public class AccelerationOfPosition
{
    public List<double> CartAccel { get; set; }
    public List<double> CartAccelAccuracy { get; set; }
    public List<double> SpherAccel { get; set; }
    public List<double> SpherAccelAccuracy { get; set; }

}

public class ObjectOrientation
{
    [RegularExpression(@"^OSD-OOR-[0-9]{1,2}[.][0-9]{1,2}$", ErrorMessage = "Header must match the pattern: OSD-OOR-<digit(s)>.<digit(s)>")]
    public string Header { get; set; } // Position Header
    public string? MInstanceID { get; set; } = null!; // ID of Virtual Space Position refers to.
    public string? ObjectOrientatinID { get; set; } // Identifier of Object Position.
    public General General { get; set; } // Set of general data    
    public Orientation? Orientation { get; set; }
    public VelocityOfOrientation? VelocityOfOrientation { get; set; }
    public AccelerationOfOrientation? AccelerationOfOrientation { get; set; }
    public string? DescrMetadata { get; set; } = null!;
}
public class Orientation
{
    public List<double> Orient { get; set; }
    public List<double> OrientAccuracy { get; set; }

}

public class VelocityOfOrientation
{
    public List<double> OrientVelocity { get; set; }
    public List<double> OrientVelocityAccuracy { get; set; }
}

public class AccelerationOfOrientation
{
    public List<double> OrientAccel { get; set; }
    public List<double> OrientAccelAccuracy { get; set; }
}



