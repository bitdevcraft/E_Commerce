using Application.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParams param)
        {
            return HandleResult(await Mediator.Send(new List.Query { Params = param }));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [AllowAnonymous]
        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands()
        {
            return HandleResult(await Mediator.Send(new Brands.Query()));
        }

        [AllowAnonymous]
        [HttpGet("types")]
        public async Task<IActionResult> GetTypes()
        {
            return HandleResult(await Mediator.Send(new Types.Query()));
        }
    }
}