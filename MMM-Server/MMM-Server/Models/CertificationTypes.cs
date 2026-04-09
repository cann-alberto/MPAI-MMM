using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public enum CertificationTypes
    {
        [JsonPropertyName("ByLaw")] ByLaw,
        [JsonPropertyName("SandBox")] SandBox
    }
}
