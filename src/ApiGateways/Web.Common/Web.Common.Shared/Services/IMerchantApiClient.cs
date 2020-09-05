using GrpcMerchants;
using System.Threading.Tasks;

namespace Web.Common.Shared.Services
{
    public interface IMerchantApiClient
    {
        Task<SearchMerchantsResponse> Search(SearchMerchantsRequest request, string token = null);
    }
}
