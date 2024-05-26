using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.Products
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<ProductDto>>>
        {
            public ProductParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<ProductDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<PagedList<ProductDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Products
                    .OrderBy(d => d.Id)
                    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();

                // Handle the Price Sorting
                query = request.Params.Sort switch
                {
                    "priceAsc" => query.OrderBy(d => d.Price),
                    "priceDesc" => query.OrderByDescending(d => d.Price),
                    _ => query.OrderBy(d => d.Id),
                };

                // Handle the Name Search
                if (!string.IsNullOrEmpty(request.Params.Search))
                {
                    query = query.Where(d => d.Name.ToLower().Contains(request.Params.Search));
                }

                return Result<PagedList<ProductDto>>.Success(await PagedList<ProductDto>.CreateAsync(query,
                        request.Params.PageNumber, request.Params.PageSize));
            }
        }
    }
}