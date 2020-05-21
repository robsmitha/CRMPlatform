using Merchants.Domain.SeedWork;
using System;

namespace Merchants.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
