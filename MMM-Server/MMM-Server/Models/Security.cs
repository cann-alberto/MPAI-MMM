using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public class Security
    {
        [Required]
        [RegularExpression(@"^AIF-SEC-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string Header { get; set; } = null!;

        [Required]
        public SecurityIdentity Identity { get; set; } = null!;

        [Required]
        public SecurityTransmission Transmission { get; set; } = null!;

        [Required]
        public SecurityIntegrity Integrity { get; set; } = null!;

        public SecurityEncryption? Encryption { get; set; }

        public SecurityTimestamps? Timestamps { get; set; }

        public DataExchangeMetadata? DataExchangeMetadata { get; set; }

        public Trace? Trace { get; set; }

        [MaxLength(2048)]
        public string? DescrMetadata { get; set; }
    }

    // ---------------------------------------------------------------------------
    // Identity
    // ---------------------------------------------------------------------------

    public class SecurityIdentity
    {
        public List<SecurityIdentitySource>? Source { get; set; }

        [Required]
        [Url]
        public string Issuer { get; set; } = null!;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CredentialType? CredentialType { get; set; }

        public string? CredentialRef { get; set; }
    }

    public class SecurityIdentitySource
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AIMInstance? AIMInstance { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? StringSource { get; set; }
    }

    public enum CredentialType
    {
        [JsonPropertyName("x509")] X509,
        [JsonPropertyName("did")] Did,
        [JsonPropertyName("psk")] Psk,
        [JsonPropertyName("custom")] Custom
    }


    // ---------------------------------------------------------------------------
    // Transmission
    // ---------------------------------------------------------------------------

    /// <summary>
    /// Describes the transmission protocol used for the data exchange.
    /// </summary>
    public class SecurityTransmission
    {
        /// <summary>
        /// Communication protocol. Required.
        /// Allowed values: "HTTPS", "MQTT", "CoAP", "WebSocket", "Custom".
        /// </summary>
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TransmissionProtocol Protocol { get; set; }

        /// <summary>
        /// Protocol version string (e.g. "1.1", "3.1.1").
        /// </summary>
        public string? Version { get; set; }

        /// <summary>
        /// Logical channel identifier for the transmission.
        /// </summary>
        public string? ChannelId { get; set; }
    }

    /// <summary>
    /// Allowed transmission protocols.
    /// </summary>
    public enum TransmissionProtocol
    {
        [JsonPropertyName("HTTPS")] Https,
        [JsonPropertyName("MQTT")] Mqtt,
        [JsonPropertyName("CoAP")] CoAp,
        [JsonPropertyName("WebSocket")] WebSocket,
        [JsonPropertyName("Custom")] Custom
    }


    // ---------------------------------------------------------------------------
    // Integrity
    // ---------------------------------------------------------------------------

    public class SecurityIntegrity
    {
        [Required]
        public IntegrityHash Hash { get; set; } = null!;

        public IntegritySignature? Signature { get; set; }
    }

    public class IntegrityHash
    {
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public HashAlgorithm Algorithm { get; set; }

        [Required]
        [RegularExpression(@"^[A-Fa-f0-9]{16,}$")]
        public string Value { get; set; } = null!;
    }

    
    public enum HashAlgorithm
    {
        [JsonPropertyName("SHA-256")] Sha256,
        [JsonPropertyName("SHA-384")] Sha384,
        [JsonPropertyName("SHA-512")] Sha512,
        [JsonPropertyName("BLAKE3")] Blake3,
        [JsonPropertyName("Custom")] Custom
    }

    
    public class IntegritySignature
    {
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SignatureAlgorithm Algorithm { get; set; }

        [Required]
        public string Value { get; set; } = null!;

        public string? PublicKeyId { get; set; }
    }

    public enum SignatureAlgorithm
    {
        [JsonPropertyName("RSA-PSS-SHA256")] RsaPssSha256,
        [JsonPropertyName("ECDSA-P256-SHA256")] EcdsaP256Sha256,
        [JsonPropertyName("Ed25519")] Ed25519,
        [JsonPropertyName("Custom")] Custom
    }


    // ---------------------------------------------------------------------------
    // Encryption
    // ---------------------------------------------------------------------------

    public class SecurityEncryption
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EncryptionAlgorithm? Algorithm { get; set; }

        public string? KeyId { get; set; }

        public string? IV { get; set; }

        public string? AAD { get; set; }

        public string? CiphertextRef { get; set; }
    }

    public enum EncryptionAlgorithm
    {
        [JsonPropertyName("AES-256-GCM")] Aes256Gcm,
        [JsonPropertyName("ChaCha20-Poly1305")] ChaCha20Poly1305,
        [JsonPropertyName("RSA-OAEP")] RsaOaep,
        [JsonPropertyName("Custom")] Custom
    }


    // ---------------------------------------------------------------------------
    // Timestamps
    // ---------------------------------------------------------------------------

    public class SecurityTimestamps
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Time? SignedAt { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Time? EncryptedAt { get; set; }
    }
}
