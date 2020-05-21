using Grpc.Core;
using Merchants.API.Application.Queries;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcMerchants
{
    public class MerchantService : Merchants.MerchantsBase
    {
        private readonly MerchantQueries _merchantQueries;
        public MerchantService(MerchantQueries merchantQueries)
        {
            _merchantQueries = merchantQueries;
        }

        [AllowAnonymous]
        public override async Task<SearchMerchantsResponse> SearchMerchants(SearchMerchantsRequest request, ServerCallContext context)
        {
            context.Status = new Status(StatusCode.OK, $"OK");

            var rows = await _merchantQueries.SearchMerchants(request.Lat, request.Lng, request.Miles, request.Location, request.Location);
            var response = new SearchMerchantsResponse { DisplayLocation = request.Location };
            if (rows != null)
            {
                var dict_merchants = new Dictionary<int, SearchMerchantModel>();
                foreach (var row in rows)
                {
                    if (!dict_merchants.TryGetValue(row.m.ID, out SearchMerchantModel merchant))
                    {
                        //TODO: map all properties
                        merchant = new SearchMerchantModel { ID = row.m.ID, Name = row.m.Name };
                        dict_merchants.Add(row.m.ID, merchant);
                    }
                }

                if (string.IsNullOrWhiteSpace(request.Keyword))
                {
                    response.Merchants.AddRange(dict_merchants.Values);
                }
                else
                {
                    //TODO: improve search
                    response.Merchants.AddRange(dict_merchants.Values
                        .Where(m => m.Name.ToLower().Contains(request.Keyword.ToLower())));
                }

            }


            return response;

        }
    }
}
