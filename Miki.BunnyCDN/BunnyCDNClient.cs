using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Miki.Net.Http;
using Newtonsoft.Json;

namespace Miki.BunnyCDN
{
    public class BunnyCDNClient
    {
        private readonly HttpClient _client;

        /// <summary>
        /// Creates an API client to BunnyCDN.
        /// </summary>
        /// <param name="accessKey">The API key provided on your bunnycdn account.</param>
        public BunnyCDNClient(string accessKey)
        {
            _client = new HttpClientFactory()
                .HasBaseUri("https://bunnycdn.com/api/")
                .CreateNew();
            _client.AddHeader("AccessKey", accessKey);
        }

        /// <summary>
        /// Returns the list of all the Pull Zones in the user's account.
        /// </summary>
        public async Task<IReadOnlyList<PullZone>> GetPullZonesAsync()
        {
            var response = await _client.GetAsync("/pullzone");
            if(response.Success)
            {
                return JsonConvert.DeserializeObject<IReadOnlyList<PullZone>>(response.Body);
            }
            return null;
        }

        /// <summary>
        /// Purge the given URL from our edge server cache.
        /// </summary>
        /// <param name="url">The URL of the file that will be purged. Use a CDN enabled URL such as http://myzone.b-cdn.net/style.css </param>
        public async Task PurgeCacheAsync(Uri url)
            => await PurgeCacheAsync(url.ToString());
        /// <summary>
        /// Purge the given URL from our edge server cache.
        /// </summary>
        /// <param name="url">The URL of the file that will be purged. Use a CDN enabled URL such as http://myzone.b-cdn.net/style.css </param>
        public async Task PurgeCacheAsync(string url)
        {
            var response = await _client.PostAsync($"/purge?url={url}");
            response.HttpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}