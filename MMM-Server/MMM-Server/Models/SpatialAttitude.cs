namespace MMM_Server.Models;

public class SpatialAttitude
{
    public Position? Position { get; set; } = null!;
    public Orientation? Orientation { get; set; } = null!;
    public Velocities? Velocities { get; set; } = null!;
    public Accelerations? Accelerations { get; set; } = null!;

}

public class Position
{
    public float X { get; set; }

    public float Y { get; set; }

    public float Z { get; set; }
}

public class Orientation
{
    public float X { get; set; }

    public float Y { get; set; }

    public float Z { get; set; }
}

public class Velocities
{
    public float X { get; set; }

    public float Y { get; set; }

    public float Z { get; set; }
}

public class Accelerations
{
    public float X { get; set; }

    public float Y { get; set; }

    public float Z { get; set; }
}
