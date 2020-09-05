using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Common.Shared.Interfaces
{
    public interface IAppUserService
    {
        /// <summary>
        /// CustomerID or UserID of current authenticated app user
        /// </summary>
        int ClaimID { get; }

        /// <summary>
        /// Email (Customer) or Username (User) of current authenticated app user
        /// </summary>
        string UniqueIdentifier { get; }

        /// <summary>
        /// Mobile phone of current authenticated app user
        /// </summary>
        string MobilePhone { get; }
    }
}
