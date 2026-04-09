using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public enum AnyAction
    {
        [JsonPropertyName("Authenticate")] Authenticate,

        [JsonPropertyName("Author")] Author,

        [JsonPropertyName("Convert")] Convert,

        [JsonPropertyName("Discover")] Discover,

        [JsonPropertyName("Execute")] Execute,

        [JsonPropertyName("Hide")] Hide,

        [JsonPropertyName("Identify")] Identify,

        [JsonPropertyName("Inform")] Inform,

        [JsonPropertyName("Interpret")] Interpret,

        [JsonPropertyName("MM-Add")] MmAdd,

        [JsonPropertyName("MM-Animate")] MmAnimate,

        [JsonPropertyName("MM-Capture")] MmCapture,

        [JsonPropertyName("MM-Move")] MmMove,

        [JsonPropertyName("MM-Send")] MmSend,

        [JsonPropertyName("Modify")] Modify,

        [JsonPropertyName("MU-Actuate")] MuActuate,

        [JsonPropertyName("MU-Add")] MuAdd,

        [JsonPropertyName("MU-Animate")] MuAnimate,

        [JsonPropertyName("MU-Move")] MuMove,

        [JsonPropertyName("MU-Send")] MuSend,

        [JsonPropertyName("Post")] Post,

        [JsonPropertyName("Property Manage")] PropertyManage,

        [JsonPropertyName("Register")] Register,

        [JsonPropertyName("Resolve")] Resolve,

        [JsonPropertyName("Rights Manage")] RightsManage,

        [JsonPropertyName("Transact")] Transact,

        [JsonPropertyName("UM-Capture")] UmCapture,

        [JsonPropertyName("UM-Send")] UmSend,

        [JsonPropertyName("Validate")] Validate
    }
}
