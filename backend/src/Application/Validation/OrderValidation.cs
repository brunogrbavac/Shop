using Application.Common.Dtos;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Queries
{
    public class OrderValidation
    {
        private readonly IAcademyDbContext _context;
        private readonly ILogger<GetDiscountCodesQuery> _logger;
        private readonly IMapper _mapper;

        public async Task<bool> ValidateOrder(OrderDto orderDto)
        {
            bool pass = true;

            for(int i = 0; i<orderDto.Products.Count;i++)
            {
                _logger.LogInformation("Getting products query.");

                var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId==orderDto.Products[i].ProductId);

                if(product==null || product.Quantity<orderDto.Products[i].Quantity)  pass = false;
            }

            return pass;
        }

    }
}
