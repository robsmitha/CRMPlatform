using Grpc.Core;
using Merchants.API.Application.Common.Extensions;
using Merchants.API.Application.Queries;
using Merchants.Domain.Aggregates.OrganizationAggregate;
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
                try
                {
                    var dict_merchants = new Dictionary<int, SearchMerchantModel>();
                    foreach (var row in rows)
                    {
                        var m = (Merchant)row.m;
                        var mi = (MerchantImage)row.mi;
                        if (!dict_merchants.ContainsKey(m.ID))
                        {
                            var merchant = new SearchMerchantModel
                            {
                                ID = m.ID,
                                Name = m.Name ?? string.Empty,
                                Description = m.Description ?? string.Empty,
                                CallToAction = m.CallToAction ?? string.Empty,
                                ShortDescription = m.ShortDescription ?? string.Empty,
                                WebsiteUrl = m.WebsiteUrl ?? string.Empty,
                                Street1 = m.Street1 ?? string.Empty,
                                Street2 = m.Street2 ?? string.Empty,
                                StateAbbreviation = m.StateAbbreviation ?? string.Empty,
                                City = m.City ?? string.Empty,
                                Zip = m.Zip ?? string.Empty,
                                Latitude = m.Latitude,
                                Longitude = m.Longitude,
                                MerchantTypeID = m.MerchantTypeID,
                                MerchantTypeName = m.MerchantType?.Name ?? string.Empty,
                                MilesAway = 0,
                                DefaultImageUrl = string.Empty,
                                Location = string.Empty,
                                DistanceAway = string.Empty
                            };
                            merchant.MilesAway = request.Lat != 0 && request.Lng != 0
                            ? m.HaversineDistance(request.Lat, request.Lng)
                            : 0.0;
                            dict_merchants.Add(m.ID, merchant);
                        }

                        if (mi != null && !string.IsNullOrEmpty(mi.ImageUrl)
                        && string.IsNullOrEmpty(dict_merchants[m.ID].DefaultImageUrl))
                            dict_merchants[m.ID].DefaultImageUrl = mi.ImageUrl;
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
                catch (System.Exception e)
                {
                    throw e;
                }
            }
            return response;
        }

        [AllowAnonymous]
        public async override Task<GetMerchantResponse> GetMerchant(GetMerchantRequest request, ServerCallContext context)
        {
            context.Status = new Status(StatusCode.OK, $"OK");
            var response = new GetMerchantResponse();
            var rows = await _merchantQueries.GetMerchant(request.MerchantID);
            var row = rows?.FirstOrDefault();
            if (row != null)
            {
                var merchant = (Merchant)row.m;
                var defaultImage = (MerchantImage)row.mi;

                //map to response
                response.ID = merchant.ID;
                response.Name = merchant.Name ?? string.Empty;
                response.Description = merchant.Description ?? string.Empty;
                response.CallToAction = merchant.CallToAction ?? string.Empty;
                response.ShortDescription = merchant.ShortDescription ?? string.Empty;
                response.WebsiteUrl = merchant.WebsiteUrl ?? string.Empty;
                response.Phone = merchant.Phone ?? string.Empty;
                response.OperatingHours = merchant.OperatingHours ?? string.Empty;
                response.ContactEmail = merchant.ContactEmail ?? string.Empty;
                response.Street1 = merchant.Street1 ?? string.Empty;
                response.Street2 = merchant.Street2 ?? string.Empty;
                response.City = merchant.City ?? string.Empty;
                response.StateAbbreviation = merchant.StateAbbreviation ?? string.Empty;
                response.Zip = merchant.Zip ?? string.Empty;
                response.Latitude = merchant.Latitude;
                response.Longitude = merchant.Longitude;
                response.MerchantTypeID = merchant.MerchantTypeID;
                response.MerchantTypeName = merchant.MerchantType?.Name ?? string.Empty;
                response.DefaultImageUrl = defaultImage?.ImageUrl ?? string.Empty;
                response.DisplayLocation = merchant.FormatLocation();
            }
            return response;
        }
    }
}
