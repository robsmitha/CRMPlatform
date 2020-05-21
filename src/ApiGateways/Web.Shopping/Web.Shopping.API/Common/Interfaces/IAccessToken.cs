using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Shopping.API.Common.Interfaces
{
    public interface IAccessToken
    {
        string token_type { get; set; }
        string access_token { get; set; }
        DateTime expires_at { get; set; }
    }
}
