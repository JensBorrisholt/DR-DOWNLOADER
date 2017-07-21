using System;
using System.Collections.Generic;
using System.Linq;

namespace Downloader.Helpers
{
    internal class M3U8File
    {
        #region Properties

        public string RawData { get; }
        public List<StreamInformation> Streams { get; } = new List<StreamInformation>();

        #endregion

        #region Constructors

        public M3U8File(string rawData)
        {
            RawData = rawData;
            var lines =
                rawData.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                       .Where(e => e.StartsWith("#EXT-X-STREAM-INF") || e.StartsWith("http"))
                       .ToList();

            var i = 0;
            while (i < lines.Count)
                Streams.Add(new StreamInformation(lines[i++], lines[i++]));

            Streams.Sort();
        }

        #endregion

        #region Members

        public StreamInformation InformationFromResolution(string reolution) => Streams.FirstOrDefault(e => e.Resolution == reolution);

        #endregion
    }
}