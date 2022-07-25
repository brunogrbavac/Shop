using Api.Common;
using Application.Commands;
using Application.Common.Dtos;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class ProductController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            return Ok(await Mediator.Send(new GetProductsQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] ProductDto productDto)
        {
            return Ok(await Mediator.Send(new InsertProductCommand { ProductDto = productDto }));
        }
    }
}
