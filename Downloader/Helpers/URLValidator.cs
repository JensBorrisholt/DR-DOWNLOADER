using System.Text.RegularExpressions;

namespace Downloader.Helpers
{
    public static class UrlValidator
    {
        private static Regex UrlRegex { get; } = new Regex(@"^http(s?)\:\/\/(www.dr.dk\/tv\/)", RegexOptions.Compiled);

        public static bool IsValidUrl(string text)
        {
            return UrlRegex.IsMatch(text);
        }
    }
}