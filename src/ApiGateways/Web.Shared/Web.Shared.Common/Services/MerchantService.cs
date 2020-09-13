using GrpcMerchants;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Shared.Common.Config;

namespace Web.Shared.Common.Services
{
    public class MerchantService : IMerchantService
    {
        private readonly ILogger<MerchantApiClient> _logger;
        private readonly UrlsConfig _urls;
        public MerchantService (ILogger<MerchantApiClient> logger, IOptions<UrlsConfig> config)
        {
            _logger = logger;
            _urls = config.Value;
        }

        public async Task<SearchMerchantsResponse> Search(SearchMerchantsRequest request)
        {
            return await GrpcCallerService.CallService(_urls.GrpcMerchants, async channel =>
            {
                var client = new Merchants.MerchantsClient(channel);
                _logger.LogDebug("grpc client created, request = {@request}", request);
                var response = await client.SearchMerchantsAsync(request);
                _logger.LogDebug("grpc response {@response}", response);

                return response;
            });
        }

        public async Task<GetMerchantResponse> GetMerchant(GetMerchantRequest request)
        {
            return await GrpcCallerService.CallService(_urls.GrpcMerchants, async channel =>
            {
                var client = new Merchants.MerchantsClient(channel);
                _logger.LogDebug("grpc client created, request = {@request}", request);
                var response = await client.GetMerchantAsync(request);
                _logger.LogDebug("grpc response {@response}", response);

                return response;
            });
        }
    }
}
