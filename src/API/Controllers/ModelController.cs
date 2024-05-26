using Application.Models;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ModelController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetListModel([FromQuery] ModelParams param)
        {
            return HandleResult(await Mediator.Send(new List.Query { Params = param }));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetModel(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateModel(Model model)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Model = model }));
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditModel(Guid id, Model model)
        {
            model.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Model = model }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
