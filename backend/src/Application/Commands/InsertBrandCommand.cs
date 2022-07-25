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

namespace Application.Commands
{
    public class InsertBrandCommand : IRequest<Brand>
    {
        public BrandDto BrandDto { get; set; }

        public class InsertBrandCommandHandler : IRequestHandler<InsertBrandCommand, Brand>
        {
            private readonly IAcademyDbContext _context;
            private readonly ILogger<GetBrandsQuery> _logger;
            private readonly IMapper _mapper;

            public InsertBrandCommandHandler(IAcademyDbContext context, ILogger<GetBrandsQuery> logger, IMapper mapper)
            {
                _context = context;
                _logger = logger;
                _mapper = mapper;
            }


            public async Task<Brand> Handle(InsertBrandCommand request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Inserting brand record!");

                try
                {
                    var brand = _mapper.Map<Brand>(request.BrandDto);

                    await _context.Brands.AddAsync(brand, cancellationToken);

                    await _context.SaveChangesAsync(cancellationToken);

                    return brand;
                }
                catch (Exception e)
                {
                    _logger.LogError($"Error inserting brand record: {e}");
                    throw;
                }

            }
        }
    }
}
