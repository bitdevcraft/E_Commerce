using Application.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetListModel([FromQuery] ProductParams param)
        {
            return HandleResult(await Mediator.Send(new List.Query { Params = param }));
        }
    }
}