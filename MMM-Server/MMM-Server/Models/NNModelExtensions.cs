using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public enum NNModelExtensions
    {
        [JsonPropertyName("engine")] Engine,
        [JsonPropertyName("h5")] H5,
        [JsonPropertyName("keras")] Keras,
        [JsonPropertyName("mlmodel")] MlModel,
        [JsonPropertyName("onnx")] Onnx,
        [JsonPropertyName("pd")] Pd,
        [JsonPropertyName("pkl")] Pkl,
        [JsonPropertyName("pt")] Pt,
        [JsonPropertyName("tflite")] TfLite
    }
}
