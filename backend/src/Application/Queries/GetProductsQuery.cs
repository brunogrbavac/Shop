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
    public class GetProductsQuery : IRequest<List<ProductDto>>
    {
        public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
        {
            private readonly IAcademyDbContext _context;
            private readonly ILogger<GetProductsQuery> _logger;
            private readonly IMapper _mapper;
            public GetProductsQueryHandler(IAcademyDbContext context, ILogger<GetProductsQuery> logger, IMapper mapper)
            {
                _context = context;
                _logger = logger;
                _mapper = mapper;
            }
            public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Getting product query.");

                var product = await _context.Products.ToListAsync(cancellationToken: cancellationToken);

                var productDto = _mapper.Map<List<ProductDto>>(product);

                return productDto;
            }
        }
    }
}
