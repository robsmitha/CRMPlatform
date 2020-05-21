using System;
using System.Collections.Generic;
using System.Text;

namespace Merchants.API.Application.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}
