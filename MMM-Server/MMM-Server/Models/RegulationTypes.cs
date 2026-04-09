using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public enum RegulationTypes
    {
        [JsonPropertyName("AI Act")] AiAct,
        [JsonPropertyName("CAIO")] Caio,
        [JsonPropertyName("Data Act")] DataAct,
        [JsonPropertyName("Data Governance Act")] DataGovernanceAct,
        [JsonPropertyName("EBSI")] Ebsi,
        [JsonPropertyName("GDPR")] Gdpr
    }
}
