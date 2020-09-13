using Shared.Domain.SeedWork;
using System;

namespace Shared.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
