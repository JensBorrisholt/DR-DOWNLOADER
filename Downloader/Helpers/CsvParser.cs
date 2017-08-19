using System.Collections.Generic;
using System.Text;

namespace Downloader.Helpers
{
    internal class CsvParser
    {
        #region Members

        public static List<string> Parse(string line)
        {
            if (string.IsNullOrEmpty(line))
                return new List<string>();

            const char escapeChar = '"';
            const char splitChar = ',';
            var inEscape = false;
            var priorEscape = false;

            var result = new List<string>();
            var sb = new StringBuilder();

            for (var i = 0; i < line.Length; i++)
            {
                var c = line[i];
                switch (c)
                {
                    case escapeChar:
                        if (!inEscape)
                        {
                            inEscape = true;
                        }
                        else
                        {
                            if (!priorEscape)
                            {
                                if (i + 1 < line.Length && line[i + 1] == escapeChar)
                                    priorEscape = true;
                                else
                                    inEscape = false;
                            }
                            else
                            {
                                sb.Append(c);
                                priorEscape = false;
                            }
                        }
                        break;
                    case splitChar:
                        if (inEscape) //if in escape
                        {
                            sb.Append(c);
                        }
                        else
                        {
                            result.Add(sb.ToString());
                            sb.Length = 0;
                        }
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }

            if (sb.Length > 0)
                result.Add(sb.ToString());

            return result;
        }

        #endregion
    }
}