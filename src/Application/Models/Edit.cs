using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Models
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Model Model { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Model).SetValidator(new ModelValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                var model = await _context.Models.FindAsync(request.Model.Id);

                if (model == null)
                    return null;

                _mapper.Map(request.Model, model);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                    return Result<Unit>.Failure("Failed to Update");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
