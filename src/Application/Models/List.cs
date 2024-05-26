using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Models
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<ModelDto>>>
        {

            public ModelParams Params { get; set; }

        }

        public class Handler : IRequestHandler<Query, Result<PagedList<ModelDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<PagedList<ModelDto>>> Handle(
                Query request,
                CancellationToken cancellationToken
            )
            {
                var query = _context.Models
                    .OrderBy(d => d.Title)
                    .ProjectTo<ModelDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();

                return Result<PagedList<ModelDto>>.Success(await PagedList<ModelDto>.CreateAsync(query,
                        request.Params.PageNumber, request.Params.PageSize));
            }
        }
    }
}
