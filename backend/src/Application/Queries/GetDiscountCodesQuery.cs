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
    public class GetDiscountCodesQuery : IRequest<List<DiscountCodeDto>>
    {
        public class GetDiscountCodesQueryHandler : IRequestHandler<GetDiscountCodesQuery, List<DiscountCodeDto>>
        {
            private readonly IAcademyDbContext _context;
            private readonly ILogger<GetDiscountCodesQuery> _logger;
            private readonly IMapper _mapper;
            public GetDiscountCodesQueryHandler(IAcademyDbContext context, ILogger<GetDiscountCodesQuery> logger, IMapper mapper)
            {
                _context = context;
                _logger = logger;
                _mapper = mapper;
            }
            public async Task<List<DiscountCodeDto>> Handle(GetDiscountCodesQuery request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Getting DiscountCode query.");

                var discountCode = await _context.DiscountCodes.ToListAsync(cancellationToken: cancellationToken);

                var discountCodeDto = _mapper.Map<List<DiscountCodeDto>>(discountCode);

                return discountCodeDto;
            }
        }
    }
}
