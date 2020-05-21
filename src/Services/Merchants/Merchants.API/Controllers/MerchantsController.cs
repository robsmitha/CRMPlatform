using System.Threading.Tasks;
using MediatR;
using Merchants.API.Application.Queries.SearchMerchants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Merchants.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MerchantsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("search")]
        public async Task<ActionResult<SearchMerchantsResponse>> SearchMerchants(SearchMerchantsRequest request = null)
        {
            return await _mediator.Send(new SearchMerchantsQuery(request));
        }
    }
}