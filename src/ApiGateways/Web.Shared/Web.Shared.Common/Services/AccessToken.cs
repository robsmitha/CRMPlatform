using System;
using Web.Shared.Common.Interfaces;

namespace Web.Shared.Common.Services
{
    public class AccessToken : IAccessToken
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
        public DateTime expires_at { get; set; }
    }
}
