using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public enum NNModelTypes
    {
        [JsonPropertyName("Convolutional-with-residuals")] ConvolutionalWithResiduals,
        [JsonPropertyName("Convolutional-without-residuals")] ConvolutionalWithoutResiduals,
        [JsonPropertyName("Deconvolutional")] Deconvolutional,
        [JsonPropertyName("Eco-State-Neural-Network")] EcoStateNeuralNetwork,
        [JsonPropertyName("Feed-Forward")] FeedForward,
        [JsonPropertyName("Modular")] Modular,
        [JsonPropertyName("Recurrent")] Recurrent,
        [JsonPropertyName("Transformer")] Transformer
    }
}
