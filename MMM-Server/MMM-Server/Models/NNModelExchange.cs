using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public enum NNModelExchange
    {
        [JsonPropertyName("NNEF")] Nnef,
        [JsonPropertyName("ONNX")] Onnx
    }
}
