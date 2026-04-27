using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public enum ThreeDModelContentFormats
    {
        [JsonPropertyName("3MF")] ThreeMF,

        [JsonPropertyName("FBX")] Fbx,

        [JsonPropertyName("glTF")] GlTF,

        [JsonPropertyName("OBJ")] Obj,

        [JsonPropertyName("PLY")] Ply,

        [JsonPropertyName("STL")] Stl,

        [JsonPropertyName("USD")] Usd
    }
}