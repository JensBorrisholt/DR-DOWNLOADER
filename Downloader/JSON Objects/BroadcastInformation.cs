using System.Collections.Generic;

namespace Downloader.JSON_Objects
{
    internal class Register
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }

    internal class Require
    {
        public List<Register> Register { get; set; }
    }

    internal class Autoload
    {
        public bool CookiePolicy { get; set; }
        public bool Footer { get; set; }
        public bool BannerAds { get; set; }
    }

    internal class PrimaryBroadcast
    {
        public string BroadcastDate { get; set; }
        public string AnnouncedStartTime { get; set; }
        public string AnnouncedEndTime { get; set; }
        public string ProductionCountry { get; set; }
        public int ProductionYear { get; set; }
        public bool VideoWidescreen { get; set; }
        public string WhatsOnUri { get; set; }
        public string Channel { get; set; }
        public string ChannelSlug { get; set; }
        public bool IsRerun { get; set; }
    }

    internal class SecondaryAsset
    {
        public string Kind { get; set; }
        public string Uri { get; set; }
        public int DurationInMilliseconds { get; set; }
        public bool Downloadable { get; set; }
        public bool RestrictedToDenmark { get; set; }
        public string StartPublish { get; set; }
        public string EndPublish { get; set; }
        public string Target { get; set; }
        public bool Encrypted { get; set; }
    }

    internal class PrimaryAsset
    {
        public string Kind { get; set; }
        public string Uri { get; set; }
        public int DurationInMilliseconds { get; set; }
        public bool Downloadable { get; set; }
        public bool RestrictedToDenmark { get; set; }
        public string StartPublish { get; set; }
        public string EndPublish { get; set; }
        public string Target { get; set; }
        public bool Encrypted { get; set; }
    }

    internal class ProgramCard
    {
        public string Description { get; set; }
        public string ProductionNumber { get; set; }
        public string PrimaryBroadcastStartTime { get; set; }
        public PrimaryBroadcast PrimaryBroadcast { get; set; }
        public List<object> Chapters { get; set; }
        public List<SecondaryAsset> SecondaryAssets { get; set; }
        public string Type { get; set; }
        public string SeriesTitle { get; set; }
        public string SeriesSlug { get; set; }
        public string SeriesUrn { get; set; }
        public bool IsNewSeries { get; set; }
        public string PrimaryChannel { get; set; }
        public string PrimaryChannelSlug { get; set; }
        public bool PrePremiere { get; set; }
        public bool ExpiresSoon { get; set; }
        public string OnlineGenreText { get; set; }
        public PrimaryAsset PrimaryAsset { get; set; }
        public bool HasPublicPrimaryAsset { get; set; }
        public string AssetTargetTypes { get; set; }
        public string Slug { get; set; }
        public string Urn { get; set; }
        public string PrimaryImageUri { get; set; }
        public string PresentationUri { get; set; }
        public string Title { get; set; }
    }

    internal class Tv
    {
        public string BasePath { get; set; }
        public string ApiBasePath { get; set; }
        public string UserBasePath { get; set; }
        public string ApiProgressBasePath { get; set; }
        public bool AppMode { get; set; }
        public string AppPlatform { get; set; }
        public bool HasPersonalization { get; set; }
        public bool HasMiniEpg { get; set; }
        public bool HasChromecast { get; set; }
        public string ChromecastReceiver { get; set; }
        public ProgramCard ProgramCard { get; set; }
    }

    internal class BroadcastInformation
    {
        public string BasePath { get; set; }
        public string ProxyUrl { get; set; }
        public Require Require { get; set; }
        public Autoload Autoload { get; set; }
        public Tv Tv { get; set; }
    }
}