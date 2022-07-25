using Api.Common;
using Application.Commands;
using Application.Common.Dtos;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class OrderController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] OrderDto orderDto)
        {
            var o = new OrderValidation();
            bool val = await o.ValidateOrder(orderDto);  

            if(val)
            {
                return Ok(await Mediator.Send(new InsertOrderCommand { OrderDto = orderDto }));
            }
            else return BadRequest();
            
        }
    }
}
