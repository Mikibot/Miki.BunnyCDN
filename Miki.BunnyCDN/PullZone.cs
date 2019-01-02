using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.BunnyCDN
{
    public class PullZone
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string OriginUrl { get; set; }
        public bool IsEnabled { get; set; }
        public IReadOnlyList<HostName> HostNames { get; set; }
        public ulong StorageZoneId { get; set; }
        public IReadOnlyList<string> AllowedReferrers { get; set; }
        public IReadOnlyList<string> BlockedIps { get; set; }
        public bool EnableGeoZoneUS { get; set; }
        public bool EnableGeoZoneEU { get; set; }
        public bool EnableGeoZoneAsia { get; set; }
        public bool ZoneSecurityEnabled { get; set; }
        public string ZoneSecurityKey { get; set; }
        public bool ZoneSecurityIncludeHashRemoteIP { get; set; }
        public bool IgnoreQueryStrings { get; set; }
        public int MonthlyBandwidthLimit { get; set; }
        public int MonthlyBandwidthUsed { get; set; }
        public bool AddHostname { get; set; }
        public PullZoneType Type { get; set; }
        public string CustomNginxConfig { get; set; }
        public IReadOnlyList<string> AccessControlOriginHeaderExtensions { get; set; }
        public bool EnableAccessControlOriginHeader { get; set; }
        public bool DisableCookies { get; set; }
        public IReadOnlyList<string> BudgetRedirectedCountries { get; set; }
        public IReadOnlyList<string> BlockedCountries { get; set; }
    }
}
