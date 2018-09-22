using System;
using System.Collections.Generic;
// ReSharper disable InconsistentNaming

namespace Downloader.JSON_Objects
{
    public class Register
    {
        public string type { get; set; }
        public string name { get; set; }
        public string path { get; set; }
    }

    public class Require
    {
        public List<Register> register { get; set; }
    }

    public class Autoload
    {
        public bool cookiePolicy { get; set; }
        public bool footer { get; set; }
        public bool bannerAds { get; set; }
    }

    public class ENV
    {
        public string mode { get; set; }
        public string port { get; set; }
        public string resolveEsi { get; set; }
    }

    public class TvNoSearchResults
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }

    public class TvRectificationModified
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Link { get; set; }
        public string LinkTitle { get; set; }
    }

    public class TvRectificationBlocked
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Link { get; set; }
        public string LinkTitle { get; set; }
    }

    public class TvThemeExpired
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Link { get; set; }
        public string LinkTitle { get; set; }
    }

    public class TvProgramExpired
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Link { get; set; }
        public string LinkTitle { get; set; }
    }

    public class TvLoadingError
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Link { get; set; }
        public string LinkTitle { get; set; }
    }

    public class Messages
    {
        public TvNoSearchResults tv_no_search_results { get; set; }
        public TvRectificationModified tv_rectification_modified { get; set; }
        public TvRectificationBlocked tv_rectification_blocked { get; set; }
        public TvThemeExpired tv_theme_expired { get; set; }
        public TvProgramExpired tv_program_expired { get; set; }
        public TvLoadingError tv_loading_error { get; set; }
    }

    public class PrimaryBroadcast
    {
        public DateTime BroadcastDate { get; set; }
        public DateTime AnnouncedStartTime { get; set; }
        public DateTime AnnouncedEndTime { get; set; }
        public string ProductionCountry { get; set; }
        public int ProductionYear { get; set; }
        public bool VideoWidescreen { get; set; }
        public string WhatsOnUri { get; set; }
        public string Channel { get; set; }
        public string ChannelSlug { get; set; }
        public bool IsRerun { get; set; }
    }

    public class SecondaryAsset
    {
        public string Kind { get; set; }
        public string Uri { get; set; }
        public int DurationInMilliseconds { get; set; }
        public bool Downloadable { get; set; }
        public bool RestrictedToDenmark { get; set; }
        public DateTime StartPublish { get; set; }
        public DateTime EndPublish { get; set; }
        public string Target { get; set; }
        public bool Encrypted { get; set; }
    }

    public class PrimaryAsset
    {
        public string Kind { get; set; }
        public string Uri { get; set; }
        public int DurationInMilliseconds { get; set; }
        public bool Downloadable { get; set; }
        public bool RestrictedToDenmark { get; set; }
        public DateTime StartPublish { get; set; }
        public DateTime EndPublish { get; set; }
        public string Target { get; set; }
        public bool Encrypted { get; set; }
    }

    public class ProgramCard
    {
        public string Description { get; set; }
        public string ProductionNumber { get; set; }
        public string ProductionCountry { get; set; }
        public int ProductionYear { get; set; }
        public string Site { get; set; }
        public string ChannelType { get; set; }
        public PrimaryBroadcast PrimaryBroadcast { get; set; }
        public List<object> Chapters { get; set; }
        public List<SecondaryAsset> SecondaryAssets { get; set; }
        public string Type { get; set; }
        public string SeriesTitle { get; set; }
        public string SeriesSlug { get; set; }
        public string SeriesUrn { get; set; }
        public string PrimaryChannel { get; set; }
        public string PrimaryChannelSlug { get; set; }
        public bool PrePremiere { get; set; }
        public bool ExpiresSoon { get; set; }
        public string OnlineGenreText { get; set; }
        public string OriginalTitle { get; set; }
        public PrimaryAsset PrimaryAsset { get; set; }
        public bool HasPublicPrimaryAsset { get; set; }
        public string AssetTargetTypes { get; set; }
        public DateTime PrimaryBroadcastStartTime { get; set; }
        public DateTime SortDateTime { get; set; }
        public string Slug { get; set; }
        public string Urn { get; set; }
        public string PrimaryImageUri { get; set; }
        public string PresentationUri { get; set; }
        public string PresentationUriAutoplay { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
    }

    public class TV
    {
        public ENV ENV { get; set; }
        public string basePath { get; set; }
        public string baseUrl { get; set; }
        public string apiBasePath { get; set; }
        public string muOnlineFullPath { get; set; }
        public string userBasePath { get; set; }
        public string apiProgressBasePath { get; set; }
        public bool appMode { get; set; }
        public string appPlatform { get; set; }
        public bool hasPersonalization { get; set; }
        public bool hasMiniEPG { get; set; }
        public Messages messages { get; set; }
        public bool hasChromecast { get; set; }
        public string chromecastReceiver { get; set; }
        public ProgramCard ProgramCard { get; set; }
    }

    public class BroadcastInformation
    {
        public string basePath { get; set; }
        public string proxyUrl { get; set; }
        public Require require { get; set; }
        public Autoload autoload { get; set; }
        public TV TV { get; set; }
    }

    
}