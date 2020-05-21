using AutoMapper;
using Merchants.API.Application.Common.Extensions;
using Merchants.API.Application.Queries.SearchMerchants;
using Merchants.Domain.Aggregates.OrganizationAggregate;
using Merchants.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merchants.API.Application.Queries
{
    public class MerchantQueries
    {
        private readonly MerchantsContext _context;
        private readonly IMapper _mapper;
        public MerchantQueries(MerchantsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<dynamic>> SearchMerchants(double lat, double lng, double miles, string location, string keyword)
        {
            var data = from m in _context.Merchants.AsEnumerable()
                       join mt in _context.MerchantTypes.AsEnumerable() on m.MerchantTypeID equals mt.ID
                       where m.WithinMiles(lat, lng, miles)
                       select new { m };

            return await Task.FromResult(data.ToList());
        }
    }
}
