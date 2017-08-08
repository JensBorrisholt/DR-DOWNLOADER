using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Downloader.Helpers.Subtitels
{
    public class SrtParser
    {
        private readonly string[] delimiters = { "-->", "- >", "->" };

        public List<SubtitleItem> Parse(string rawString)
        {
            var result = new List<SubtitleItem>();
            var strSubParts = rawString.Split(new[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var srtSubPart in strSubParts)
            {
                var lines = srtSubPart.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Select(s => s.Trim()).Where(l => !string.IsNullOrEmpty(l));

                var item = new SubtitleItem();
                foreach (var line in lines)
                {
                    if (item.StartTime == 0 && item.EndTime == 0)
                    {
                        if (TryParseTimecodeLine(line, out int startTc, out int endTc))
                        {
                            item.StartTime = startTc;
                            item.EndTime = endTc;
                        }
                    }
                    else
                        item.Lines.Add(line);
                }

                if (item.IsValid())
                    result.Add(item);
            }

            return result;
        }

        private bool TryParseTimecodeLine(string line, out int startTc, out int endTc)
        {
            var parts = line.Split(delimiters, StringSplitOptions.None);
            if (parts.Length != 2)
            {
                startTc = -1;
                endTc = -1;
                return false;
            }

            startTc = ParseSrtTimecode(parts[0]);
            endTc = ParseSrtTimecode(parts[1]);
            return true;
        }

        private static int ParseSrtTimecode(string s)
        {
            var match = Regex.Match(s, "[0-9]+:[0-9]+:[0-9]+([,\\.][0-9]+)?");
            if (!match.Success)
                return -1;

            if (TimeSpan.TryParse(match.Value.Replace(',', '.'), out var result))
                return (int)result.TotalMilliseconds;

            return -1;
        }
    }
}