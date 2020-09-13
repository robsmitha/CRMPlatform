using GrpcMerchants;
using System.Threading.Tasks;

namespace Web.Shared.Common.Services
{
    public interface IMerchantService
    {
        Task<SearchMerchantsResponse> Search(SearchMerchantsRequest request);
        Task<GetMerchantResponse> GetMerchant(GetMerchantRequest request);
    }
}
