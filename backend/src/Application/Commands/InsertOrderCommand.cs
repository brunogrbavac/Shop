using System;
using Application.Common.Dtos;
using Application.Common.Interfaces;
using Application.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entites;
using System.Collections.Generic;

namespace Application.Commands
{
    public class InsertOrderCommand : IRequest<Order>
    {
        public OrderDto OrderDto { get; set; }

        public class InsertOrderCommandHandler : IRequestHandler<InsertOrderCommand, Order>
        {
            private readonly IAcademyDbContext _context;
            private readonly ILogger<GetProductsQuery> _logger;
            private readonly IMapper _mapper;

            public InsertOrderCommandHandler(IAcademyDbContext context, ILogger<GetProductsQuery> logger, IMapper mapper)
            {
                _context = context;
                _logger = logger;
                _mapper = mapper;
            }


            public async Task<Order> Handle(InsertOrderCommand request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Inserting product record!");

                try
                {
                    var order = _mapper.Map<Order>(request.OrderDto);

                    await _context.Orders.AddAsync(order, cancellationToken);

                    await _context.SaveChangesAsync(cancellationToken);

                    return order;
                }
                catch (Exception e)
                {
                    _logger.LogError($"Error inserting product record: {e}");
                    throw;
                }

            }

        }
    }
}
