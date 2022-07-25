using Api.Common;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class DiscountCodeController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetDiscountCodes()
        {
            return Ok(await Mediator.Send(new GetDiscountCodesQuery()));
        }

    }
}
