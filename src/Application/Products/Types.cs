using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class Types
    {
        public class Query : IRequest<Result<List<ProductType>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<ProductType>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<ProductType>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var types = await _context.ProductTypes
                    .ToListAsync(cancellationToken: cancellationToken);

                return Result<List<ProductType>>.Success(types);
            }
        }
    }
}