using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.BunnyCDN
{
    public class HostName
    {
        public ulong Id { get; set; }

        /// <summary>
        /// The full hostname domain value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// True if the hostname will force the users to use a SSL connection
        /// </summary>
        public bool ForceSSL { get; set; }

        /// <summary>
        /// True if the hostname is a system hostname
        /// </summary>
        public bool IsSystemHostname { get; set; }

        /// <summary>
        /// True if the hostname is configured with an SSL certificate
        /// </summary>
        public bool HasCertificate { get; set; }
    }
}
