using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AppCompanies
{
    public class Edit
    {
        public class Command : IRequest<Result<AppCompany>>
        {
            public AppCompany Company { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<AppCompany>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<AppCompany>> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                var company = await _context
                    .AppCompanies.OrderBy(x => x.Name)
                    .FirstOrDefaultAsync();

                if (company == null)
                    return null;

                request.Company.Id = company.Id;
                _mapper.Map(request.Company, company);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                    return Result<AppCompany>.Failure("Failed to Update");

                return Result<AppCompany>.Success(request.Company);
            }
        }
    }
}
