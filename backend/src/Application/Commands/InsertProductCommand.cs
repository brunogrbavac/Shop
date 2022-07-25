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
    public class InsertProductCommand : IRequest<Product>
    {
        public ProductDto ProductDto { get; set; }

        public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, Product>
        {
            private readonly IAcademyDbContext _context;
            private readonly ILogger<GetProductsQuery> _logger;
            private readonly IMapper _mapper;

            public InsertProductCommandHandler(IAcademyDbContext context, ILogger<GetProductsQuery> logger, IMapper mapper)
            {
                _context = context;
                _logger = logger;
                _mapper = mapper;
            }


            public async Task<Product> Handle(InsertProductCommand request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Inserting product record!");

                try
                {
                    var product = _mapper.Map<Product>(request.ProductDto);

                    await _context.Products.AddAsync(product, cancellationToken);

                    await _context.SaveChangesAsync(cancellationToken);

                    return product;
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
