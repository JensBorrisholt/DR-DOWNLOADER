using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Downloader.Helpers
{
    internal class StreamInformation : IEquatable<StreamInformation>, IComparable<StreamInformation>
    {
        #region Fields

        private static readonly Regex ResolutionExpr = new Regex(@"\d{3,4}", RegexOptions.Compiled);

        #endregion

        #region Properties

        public int BandWidth { get; private set; }
        public Dictionary<string, string> Properties { get; } = new Dictionary<string, string>();
        public string RawDescription { get; }

        public string Resolution { get; private set; }
        public string Uri { get; }

        #endregion

        #region Constructors

        public StreamInformation(string description, string streamUri)
        {
            RawDescription = description;
            Uri = streamUri;
            Parse();
        }

        #endregion

        #region Members

        private void Parse()
        {
            foreach (var keyValue in CsvParser.Parse(RawDescription).Select(element => element.Split('=')))
                Properties.Add(keyValue[0], keyValue[1]);

            Resolution = PropertyByName("RESOLUTION");
            BandWidth = int.TryParse(PropertyByName("BANDWIDTH"), out int dummy) ? dummy : 0;
        }

        public string PropertyByName(string name) => Properties.FirstOrDefault(e => e.Key == name).Value;

        #endregion

        #region Interface Implementations

        public int CompareTo(StreamInformation other)
        {
            var resulutionX = ResolutionExpr.Match(Resolution ?? "0000").Value;
            var resulutionY = ResolutionExpr.Match(Resolution ?? "0000").Value;

            var result = Comparer<int>.Default.Compare(int.Parse(resulutionX), int.Parse(resulutionY));
            if (result == 0)
                result = Comparer<int>.Default.Compare(BandWidth, other.BandWidth);
            return result;
        }

        public bool Equals(StreamInformation other) => other?.Resolution == Resolution;

        #endregion
    }
}