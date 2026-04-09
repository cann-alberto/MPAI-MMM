using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public enum CoordinateTypes
    {
        [JsonPropertyName("Cartesian")] Cartesian,

        [JsonPropertyName("Spherical")] Spherical,

        [JsonPropertyName("Geodesic")] Geodesic,

        [JsonPropertyName("Toroidal")] Toroidal
    }
}