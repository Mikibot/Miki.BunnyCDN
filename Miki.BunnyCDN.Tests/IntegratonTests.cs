using System;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Xunit;

namespace Miki.BunnyCDN.Tests
{
    public class IntegratonTests
    {
        internal class ConfigurableConstants
        {
            internal static string Url => $"https://{Hostname}.b-cdn.net";

            /// <summary>
            /// Can be found on your dashboard/pullzones.
            /// </summary>
            internal static string Hostname = "mikido";
            /// <summary>
            /// Example: "/css/style.css".
            /// </summary>
            internal static string PurgableFile = "/avatars/191964807404978176.png";
        }

        private readonly BunnyCDNClient _client;

        public IntegratonTests()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<IntegratonTests>()
                .Build();

            _client = new BunnyCDNClient(config["apikey"]);
        }

        [Fact]
        public async Task PurgeTestAsync()
        {
            await _client.PurgeCacheAsync(ConfigurableConstants.Url + ConfigurableConstants.PurgableFile);
        }
    }
}
