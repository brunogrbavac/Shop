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
    public class GetBrandsQuery : IRequest<List<BrandDto>>
    {
        public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, List<BrandDto>>
        {
            private readonly IAcademyDbContext _context;
            private readonly ILogger<GetBrandsQuery> _logger;
            private readonly IMapper _mapper;
            public GetBrandsQueryHandler(IAcademyDbContext context, ILogger<GetBrandsQuery> logger, IMapper mapper)
            {
                _context = context;
                _logger = logger;
                _mapper = mapper;
            }
            public async Task<List<BrandDto>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Getting brand query.");

                var brand = await _context.Brands.ToListAsync(cancellationToken: cancellationToken);

                var brandDto = _mapper.Map<List<BrandDto>>(brand);

                return brandDto;
            }
        }
    }
}
