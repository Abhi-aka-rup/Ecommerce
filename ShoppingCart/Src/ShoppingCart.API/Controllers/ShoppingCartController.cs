using Microsoft.AspNetCore.Mvc;
using ShoppingCartAPI.Application.ShoppingCart.Commands.CreateShoppingCart;
using ShoppingCartAPI.Application.ShoppingCart.Queries.GetShoppingCartList;

namespace ShoppingCart.API.Controllers
{
    public class ShoppingCartController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ShoppingCartListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetShoppingCartListQuery());
            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateShoppingCartCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
