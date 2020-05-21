using GrpcMerchants;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Shopping.API.Common.Config;

namespace Web.Shopping.API.Services
{
    public class MerchantApiClient : IMerchantApiClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<MerchantApiClient> _logger;
        private readonly UrlsConfig _urls;
        public MerchantApiClient(HttpClient httpClient, ILogger<MerchantApiClient> logger, IOptions<UrlsConfig> config)
        {
            _client = httpClient;
            _logger = logger;
            _urls = config.Value;
        }

        public async Task<SearchMerchantsResponse> Search(SearchMerchantsRequest request, string token = null)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                var requestUri = _urls.Merchants + UrlsConfig.MerchantOperations.SearchMerchants();
                var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(requestUri, content);
                return response.IsSuccessStatusCode
                    ? JsonSerializer.Deserialize<SearchMerchantsResponse>(response.Content.ReadAsStringAsync().Result)
                    : default;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }
    }
}
