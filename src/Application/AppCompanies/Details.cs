using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AppCompanies
{
    public class Details
    {
        public class Query : IRequest<Result<AppCompany>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<AppCompany>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
            _context = context;
            }

            public async Task<Result<AppCompany>> Handle(Query request, CancellationToken cancellationToken)
            {
                var company = await _context.AppCompanies.FirstOrDefaultAsync();

                if(company == null)
                    return null;
                
                return Result<AppCompany>.Success(company);
            }
        }
    }
}