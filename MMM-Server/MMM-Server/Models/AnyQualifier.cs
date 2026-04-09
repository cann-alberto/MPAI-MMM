using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public class AnyQualifier
    {
        [RegularExpression(@"^OSD-AQF-V[0-9]{1,2}[.][0-9]{1,2}$")]
        public string? Header { get; set; }

        public string? MInstanceID { get; set; }

        public string? QualifiersID { get; set; }

        public List<AnyQualifierEntry>? Qualifiers { get; set; }

        [MaxLength(2048)]
        public string? DescrMetadata { get; set; }
    }


    // ---------------------------------------------------------------------------
    // AnyQualifierEntry — anyOf: one populated qualifier property per entry
    // ---------------------------------------------------------------------------

    public class AnyQualifierEntry
    {
        /// <summary>
        /// GNSS (GPS) data qualifier.
        /// ⚠️ EXTERNAL REFERENCE: GNSSQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/GNSSQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GNSSQualifier? GNSSQualifier { get; set; }

        /// <summary>
        /// LiDAR sensor data qualifier.
        /// ⚠️ EXTERNAL REFERENCE: LiDARQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/LiDARQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LiDARQualifier? LiDARQualifier { get; set; }

        /// <summary>
        /// Offline map data qualifier.
        /// ⚠️ EXTERNAL REFERENCE: OfflineMapQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/OfflineMapQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public OfflineMapQualifier? OfflineMapQualifier { get; set; }

        /// <summary>
        /// RADAR sensor data qualifier.
        /// ⚠️ EXTERNAL REFERENCE: RADARQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/RADARQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RADARQualifier? RADARQualifier { get; set; }

        /// <summary>
        /// Ultrasound sensor data qualifier.
        /// ⚠️ EXTERNAL REFERENCE: UltrasoundQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/UltrasoundQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UltrasoundQualifier? UltrasoundQualifier { get; set; }

        /// <summary>
        /// Body descriptors qualifier.
        /// ⚠️ EXTERNAL REFERENCE: BodyDescriptorsQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/BodyDescriptorsQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BodyDescriptorsQualifier? BodyDescriptorsQualifier { get; set; }

        /// <summary>
        /// Face descriptors qualifier.
        /// ⚠️ EXTERNAL REFERENCE: FaceDescriptorsQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/FaceDescriptorsQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FaceDescriptorsQualifier? FaceDescriptorsQualifier { get; set; }

        /// <summary>
        /// Gesture descriptors qualifier.
        /// ⚠️ EXTERNAL REFERENCE: GestureDescriptorsQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/GestureDescriptorsQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GestureDescriptorsQualifier? GestureDescriptorsQualifier { get; set; }

        /// <summary>
        /// Motion capture qualifier.
        /// ⚠️ EXTERNAL REFERENCE: MoCapQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/MoCapQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MoCapQualifier? MoCapQualifier { get; set; }

        /// <summary>
        /// Behavioural signal qualifier.
        /// ⚠️ EXTERNAL REFERENCE: BehaviouralSignalQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/BehaviouralSignalQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("BehaviouralSignal")]
        public BehaviouralSignalQualifier? BehaviouralSignal { get; set; }

        /// <summary>
        /// Electronic Health Record qualifier.
        /// ⚠️ EXTERNAL REFERENCE: EHRQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/EHRQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EHRQualifier? EHRQualifier { get; set; }

        /// <summary>
        /// Genomics / omics data qualifier.
        /// ⚠️ EXTERNAL REFERENCE: GenomicsOmicsQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/GenomicsOmicsQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("GenomicsOmics")]
        public GenomicsOmicsQualifier? GenomicsOmics { get; set; }

        /// <summary>
        /// Medical image qualifier.
        /// ⚠️ EXTERNAL REFERENCE: MedicalImageQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/MedicalImageQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MedicalImageQualifier? MedicalImageQualifier { get; set; }

        /// <summary>
        /// Neurophysiological signal qualifier.
        /// ⚠️ EXTERNAL REFERENCE: NeurophysiologicalSignalQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/NeurophysiologicalSignalQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public NeurophysiologicalSignalQualifier? NeurophysiologicalSignalQualifier { get; set; }

        /// <summary>
        /// Physiological signal qualifier.
        /// ⚠️ EXTERNAL REFERENCE: PhysiologicalSignalQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/PhysiologicalSignalQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PhysiologicalSignalQualifier? PhysiologicalSignalQualifier { get; set; }

        /// <summary>
        /// ML model qualifier. References the already-defined MLModelQualifier class. ✅
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MLModelQualifier? MLModelQualifier { get; set; }

        /// <summary>
        /// 3D model qualifier.
        /// ⚠️ EXTERNAL REFERENCE: ThreeDModelQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/3DModelQualifier.json"
        /// Note: C# identifiers cannot start with a digit; property name is
        /// mapped to "3DModelQualifier" via JsonPropertyName.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("3DModelQualifier")]
        public ThreeDModelQualifier? ThreeDModelQualifier { get; set; }

        /// <summary>
        /// Audio data qualifier.
        /// ⚠️ EXTERNAL REFERENCE: AudioQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/AudioQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AudioQualifier? AudioQualifier { get; set; }

        /// <summary>
        /// Audio-visual data qualifier.
        /// ⚠️ EXTERNAL REFERENCE: AudioVisualQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/AudioVisualQualifier.json"
        /// Note: JSON property name preserves the hyphen: "Audio-VisualQualifier".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("Audio-VisualQualifier")]
        public AudioVisualQualifier? AudioVisualQualifier { get; set; }

        /// <summary>
        /// Colour data qualifier.
        /// ⚠️ EXTERNAL REFERENCE: ColourQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/ColourQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ColourQualifier? ColourQualifier { get; set; }

        /// <summary>
        /// Speech data qualifier.
        /// ⚠️ EXTERNAL REFERENCE: SpeechQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/SpeechQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SpeechQualifier? SpeechQualifier { get; set; }

        /// <summary>
        /// Text data qualifier.
        /// ⚠️ EXTERNAL REFERENCE: TextQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/TextQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TextQualifier? TextQualifier { get; set; }

        /// <summary>
        /// Visual data qualifier.
        /// ⚠️ EXTERNAL REFERENCE: VisualQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/VisualQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VisualQualifier? VisualQualifier { get; set; }

        /// <summary>
        /// Certificate qualifier.
        /// ⚠️ EXTERNAL REFERENCE: CertificateQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/CertificateQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CertificateQualifier? CertificateQualifier { get; set; }

        /// <summary>
        /// Contract qualifier.
        /// ⚠️ EXTERNAL REFERENCE: ContractQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/ContractQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ContractQualifier? ContractQualifier { get; set; }

        /// <summary>
        /// Currency qualifier. References the already-defined CurrencyQualifier class. ✅
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CurrencyQualifier? CurrencyQualifier { get; set; }

        /// <summary>
        /// Discovery qualifier.
        /// ⚠️ EXTERNAL REFERENCE: DiscoveryQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/DiscoveryQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DiscoveryQualifier? DiscoveryQualifier { get; set; }

        /// <summary>
        /// Interpretation qualifier.
        /// ⚠️ EXTERNAL REFERENCE: InterpretationQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/InterpretationQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public InterpretationQualifier? InterpretationQualifier { get; set; }

        /// <summary>
        /// Program qualifier.
        /// ⚠️ EXTERNAL REFERENCE: ProgramQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/ProgramQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ProgramQualifier? ProgramQualifier { get; set; }

        /// <summary>
        /// Location qualifier.
        /// ⚠️ EXTERNAL REFERENCE: LocationQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/LocationQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LocationQualifier? LocationQualifier { get; set; }

        /// <summary>
        /// Time qualifier. References the already-defined TimeQualifier class. ✅
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TimeQualifier? TimeQualifier { get; set; }

        /// <summary>
        /// Control qualifier.
        /// ⚠️ EXTERNAL REFERENCE: ControlQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/ControlQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ControlQualifier? ControlQualifier { get; set; }

        /// <summary>
        /// Dance qualifier.
        /// ⚠️ EXTERNAL REFERENCE: DanceQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/DanceQualifier.json"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DanceQualifier? DanceQualifier { get; set; }

        /// <summary>
        /// Metaverse API qualifier.
        /// ⚠️ EXTERNAL REFERENCE: MetaverseQualifier
        /// "$ref": "https://schemas.mpai.community/TFA/V1.5/data/MetaverseQualifier.json"
        /// Note: JSON property name is "MetaverseAPI" as defined in the schema.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("MetaverseAPI")]
        public MetaverseQualifier? MetaverseAPI { get; set; }
    }
}
