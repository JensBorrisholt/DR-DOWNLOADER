using System;
using System.Collections.Generic;
using System.Linq;

namespace Downloader.Helpers.Subtitels
{
    public class SubtitleItem
    {
        public SubtitleItem()
        {
            Lines = new List<string>();
        }

        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public List<string> Lines { get; set; }

        public bool IsValid()
        {
            return StartTime * EndTime >= 0 && Lines.Any();
        }

        public override string ToString()
        {
            var startTs = new TimeSpan(0, 0, 0, 0, StartTime);
            var endTs = new TimeSpan(0, 0, 0, 0, EndTime);
            return
                $"{startTs:G} --> {endTs:G}{Environment.NewLine}{string.Join(Environment.NewLine, Lines)}{Environment.NewLine}";
        }
    }
}