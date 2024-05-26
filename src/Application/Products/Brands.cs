using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class Brands
    {
        public class Query : IRequest<Result<List<ProductBrand>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<ProductBrand>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<ProductBrand>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var brands = await _context.ProductBrands
                    .ToListAsync(cancellationToken: cancellationToken);

                return Result<List<ProductBrand>>.Success(brands);
            }
        }
    }
}