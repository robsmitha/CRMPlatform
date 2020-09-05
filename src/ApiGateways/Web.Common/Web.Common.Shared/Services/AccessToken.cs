using System;
using Web.Common.Shared.Interfaces;

namespace Web.Common.Shared.Services
{
    public class AccessToken : IAccessToken
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
        public DateTime expires_at { get; set; }
    }
}
