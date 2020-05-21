using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Shopping.API.Common.Interfaces
{
    public interface IAppUser
    {
        /// <summary>
        /// Indicate client's jwt token httpOnlyCookie is valid if exists
        /// </summary>
        public bool authenticated { get; set; }
    }
}
