using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public enum NNModelFrameworks
    {
        [JsonPropertyName("ai")] Ai,
        [JsonPropertyName("Caffe")] Caffe,
        [JsonPropertyName("CNTK")] Cntk,
        [JsonPropertyName("Keras")] Keras,
        [JsonPropertyName("MxNet")] MxNet,
        [JsonPropertyName("PyTorch")] PyTorch,
        [JsonPropertyName("Scikit-Learn")] ScikitLearn,
        [JsonPropertyName("TensorFlow")] TensorFlow
    }
}
