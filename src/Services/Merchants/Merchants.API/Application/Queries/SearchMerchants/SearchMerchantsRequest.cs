using System;
using System.Collections.Generic;
using System.Text;

namespace Merchants.API.Application.Queries.SearchMerchants
{
    public class SearchMerchantsRequest
    {
        public string Keyword { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int Miles { get; set; }
        public string Location { get; set; }
    }

}
