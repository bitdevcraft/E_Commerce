using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.AppCompanies;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AppCompanyController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCompany()
        {
            return HandleResult(await Mediator.Send(new Details.Query()));
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> EditModel(AppCompany company)
        {
            return HandleResult(await Mediator.Send(new Edit.Command { Company = company }));
        }
    }
}