using Application.Core;
using MediatR;
using Persistence;

namespace Application.Models
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                var model = await _context.Models.FindAsync(request.Id);

                if (model == null)
                    return null;

                _context.Remove(model);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                    return Result<Unit>.Failure("Problem Deleting the Request");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
