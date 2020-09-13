using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Domain.SeedWork
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}
