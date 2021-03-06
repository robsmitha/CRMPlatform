﻿using GrpcMerchants;
using System.Threading.Tasks;

namespace Web.Shared.Common.Services
{
    public interface IMerchantApiClient
    {
        Task<SearchMerchantsResponse> Search(SearchMerchantsRequest request, string token = null);
    }
}
