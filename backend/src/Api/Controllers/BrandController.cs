using Api.Common;
using Application.Commands;
using Application.Common.Dtos;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class BrandController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            return Ok(await Mediator.Send(new GetBrandsQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> PostBrand([FromBody] BrandDto brandDto)
        {
            return Ok(await Mediator.Send(new InsertBrandCommand { BrandDto = brandDto }));
        }
    }
}
