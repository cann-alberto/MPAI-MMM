using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public enum ThreeDModelTransportFormats
    {
        [JsonPropertyName("DASH")] Dash,

        [JsonPropertyName("HLS")] Hls,

        [JsonPropertyName("MPEG-I OMAF")] MpegIOmaf,

        [JsonPropertyName("WebRTC")] WebRtc,

        [JsonPropertyName("RTSP")] Rtsp,

        [JsonPropertyName("HTTP Progressive")] HttpProgressive
    }
}