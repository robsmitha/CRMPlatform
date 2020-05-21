using GrpcMerchants;
using System.Threading.Tasks;

namespace Web.Shopping.API.Services
{
    public interface IMerchantApiClient
    {
        Task<SearchMerchantsResponse> Search(SearchMerchantsRequest request, string token = null);
    }
}
