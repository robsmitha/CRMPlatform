using AutoMapper;
using GrpcMerchants;
using MediatR;
using Merchants.Domain.Aggregates.OrganizationAggregate;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Merchants.API.Application.Queries.SearchMerchants
{
    public class SearchMerchantsQuery : IRequest<SearchMerchantsResponse>
    {
        public string Keyword { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Miles { get; set; }
        public string Location { get; set; }

        public SearchMerchantsQuery(SearchMerchantsRequest request)
        {
            if (request == null) return;
            Keyword = request.Keyword;
            Latitude = request.Lat;
            Longitude = request.Lng;
            Miles = request.Miles > 0 ? request.Miles : int.MaxValue;
            Location = request.Location;
        }

        public class SearchMerchantsQueryHandler : IRequestHandler<SearchMerchantsQuery, SearchMerchantsResponse>
        {
            private readonly IMapper _mapper;
            private readonly MerchantQueries _merchantQueries;
            public SearchMerchantsQueryHandler(MerchantQueries merchantQueries, IMapper mapper)
            {
                _merchantQueries = merchantQueries;
                _mapper = mapper;
            }
            public async Task<SearchMerchantsResponse> Handle(SearchMerchantsQuery request, CancellationToken cancellationToken)
            {
                var rows = await _merchantQueries.SearchMerchants(request.Latitude, request.Longitude, request.Miles, request.Location, request.Location);
                var response = new SearchMerchantsResponse(displayLocation: request.Location);
                if (rows != null)
                {
                    var dict_merchants = new Dictionary<int, SearchMerchantModel>();
                    foreach (var row in rows)
                    {
                        if (!dict_merchants.TryGetValue(row.m.ID, out SearchMerchantModel merchant))
                        {
                            merchant = _mapper.Map<SearchMerchantModel>((Merchant)row.m);
                            dict_merchants.Add(row.m.ID, merchant);
                        }
                    }

                    List<SearchMerchantModel> merchants;
                    if (string.IsNullOrWhiteSpace(request.Keyword))
                    {
                        merchants = dict_merchants.Values.ToList();
                    }
                    else
                    {
                        //TODO: improve search
                        merchants = dict_merchants.Values
                            .Where(m => m.Name.ToLower().Contains(request.Keyword.ToLower()))
                            .ToList();
                    }
                    if (merchants.Any())
                        response.Merchants.AddRange(merchants);
                }

                return response;
            }
        }
    }
}
