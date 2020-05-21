using System;
using Web.Shopping.API.Common.Interfaces;

namespace Web.Shopping.API.Services
{
    public class AccessToken : IAccessToken
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
        public DateTime expires_at { get; set; }
    }
}
