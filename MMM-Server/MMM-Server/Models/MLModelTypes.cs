using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public enum MLModelTypes
    {
        [JsonPropertyName("Bayesian-Classifier")] BayesianClassifier,
        [JsonPropertyName("Neural-Network")] NeuralNetwork,
        [JsonPropertyName("Random-Forest")] RandomForest,
        [JsonPropertyName("Support-Vector-Machine")] SupportVectorMachine,
        [JsonPropertyName("XG-Boost")] XgBoost,
        [JsonPropertyName("Format")] Format
    }
}
