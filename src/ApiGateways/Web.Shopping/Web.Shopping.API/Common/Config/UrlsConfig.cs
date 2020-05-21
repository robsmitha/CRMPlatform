using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Shopping.API.Common.Config
{
    public class UrlsConfig
    {
        public class MerchantOperations
        {
            public static string SearchMerchants() => $"/api/v1/merchants/search";
            public static string GetMerchant(int merchantId) => $"/api/v1/merchants/{merchantId}";
            public static string GetMerchantItems(int merchantId) => $"/api/v1/merchants/{merchantId}/items";
            public static string GetMerchantWorkflow(int merchantId) => $"/api/v1/merchants/{merchantId}";
            public static string GetItem(int merchantId, int itemId) => $"/api/v1/merchants/{merchantId}/items/{itemId}";
        }
       
        public string Merchants { get; set; }
        public string GrpcMerchants { get; set; }
    }
}
