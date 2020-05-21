using System.Collections.Generic;

namespace Merchants.API.Application.Queries.SearchMerchants
{
    public class SearchMerchantsResponse
    {
        public SearchMerchantsResponse(string displayLocation, List<SearchMerchantModel> merchants = null)
        {
            DisplayLocation = displayLocation;
            Merchants = merchants ?? new List<SearchMerchantModel>();
        }
        public string DisplayLocation { get; set; }
        public List<SearchMerchantModel> Merchants { get; private set; }
    }
}
