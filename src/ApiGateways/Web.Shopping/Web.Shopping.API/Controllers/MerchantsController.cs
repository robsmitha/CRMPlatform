using System.Threading.Tasks;
using GrpcMerchants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Shopping.API.Services;

namespace Web.Shopping.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MerchantsController : ControllerBase
    {
        public readonly IMerchantService _merchantService;
        public MerchantsController(IMerchantService merchantService)
        {
            _merchantService = merchantService;
        }

        //[AllowAnonymous]
        [HttpPost("search")]
        public async Task<ActionResult<SearchMerchantsResponse>> SearchMerchants(SearchMerchantsRequest request = null)
        {
            return await _merchantService.Search(request);
        }
    }
}