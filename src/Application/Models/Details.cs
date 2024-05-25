using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Models
{
    public class Details
    {
        public class Query : IRequest<Result<Model>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Model>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Model>> Handle(
                Query request,
                CancellationToken cancellationToken
            )
            {
                var model = await _context.Models.FindAsync(request.Id);

                if (model == null)
                    return null;

                return Result<Model>.Success(model);
            }
        }
    }
}
