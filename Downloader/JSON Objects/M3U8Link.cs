using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace Downloader.JSON_Objects
{
    internal class M3u8Link
    {
        #region Properties

        public string EncryptedUri { get; set; }
        public string FileFormat { get; set; }
        public string HardSubtitlesType { get; set; }
        public string Target { get; set; }
        public string Uri { get; set; }

        #endregion
    }

    internal class Subtitle
    {
        public string Language { get; set; }
        public string MimeType { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    internal class M3u8Object
    {
        public List<M3u8Link> Links { get; set; }
        public List<Subtitle> SubtitlesList { get; set; }
    }
}