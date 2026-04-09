using System.Text.Json.Serialization;

namespace MMM_Server.Models
{
    public enum TimeFormats
    {
        /// <summary>
        /// Part 1 of the SMPTE 12M standard defining the structure and encoding
        /// of SMPTE timecode used for identifying individual video/audio frames.
        /// </summary>
        [JsonPropertyName("SMPTE 12M-1")] Smpte12M1,

        /// <summary>
        /// Part 2 of the SMPTE 12M standard providing metadata rules,
        /// clarifications, and additional conventions for SMPTE timecode usage.
        /// </summary>
        [JsonPropertyName("SMPTE 12M-2")] Smpte12M2,

        /// <summary>
        /// MIDI Time Code (MTC) — a musical time-synchronization format
        /// representing SMPTE-style time positions using MIDI messages.
        /// </summary>
        [JsonPropertyName("MIDI/MTC")] MidiMtc,

        /// <summary>
        /// International standard for unambiguous date and time representation,
        /// including calendar dates, times, time offsets, and combined formats.
        /// </summary>
        [JsonPropertyName("ISO 8601")] Iso8601,

        /// <summary>
        /// A strict Internet profile of ISO 8601 defining timestamp formats
        /// used widely in web protocols and JSON APIs.
        /// </summary>
        [JsonPropertyName("IETF RFC 3339")] IetfRfc3339,

        /// <summary>
        /// Linear Time Code — SMPTE timecode encoded as an audio-like waveform
        /// for frame-accurate synchronization in audio/video systems.
        /// </summary>
        [JsonPropertyName("LTC")] Ltc,

        /// <summary>
        /// Vertical Interval Time Code — SMPTE timecode embedded in the vertical
        /// blanking interval of a video signal for frame labeling.
        /// </summary>
        [JsonPropertyName("VITC")] Vitc,

        /// <summary>
        /// Ancillary Time Code (LTC variant) — packetized SMPTE LTC stored
        /// in the ancillary space of HD-SDI streams.
        /// </summary>
        [JsonPropertyName("ATC_LTC")] AtcLtc,

        /// <summary>
        /// Ancillary Time Code (VITC variant) — packetized SMPTE VITC embedded
        /// in the ancillary data space of HD-SDI streams.
        /// </summary>
        [JsonPropertyName("ATC_VITC")] AtcVitc,

        /// <summary>
        /// IRIG-B — a widely used Inter-Range Instrumentation Group timecode
        /// format for precise time-of-day distribution in instrumentation
        /// and aerospace systems.
        /// </summary>
        [JsonPropertyName("IRIG-B")] IrigB
    }
}
