using Microsoft.AspNetCore.Mvc;
using RetailInMotion.OrdersManagement.Api.DTOs;
using RetailInMotion.OrdersManagement.Core.DTOs;
using RetailInMotion.OrdersManagement.Core.Interfaces;

namespace RetailInMotion.OrderManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
            => Ok(await _orderService.GetAllAsync());

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await _orderService.GetByIdAsync(id));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] OrderDTO order)
        {
            await _orderService.CreateAsync(order);

            return Ok();
        }

        [HttpPut("{id}/deliveryAddress")]
        public async Task<IActionResult> Put(Guid id, [FromBody] string deliveryAddress)
        {
            await _orderService.UpdateDeliveryAddressAsync(id, deliveryAddress);

            return Ok($"{nameof(deliveryAddress)} updated successfully!");
        }

        [HttpPut("{id}/products")]
        public async Task<IActionResult> Put(Guid id, [FromBody] IEnumerable<ProductDTO> products)
        {
            await _orderService.UpdateProductsAsync(id, products);

            return Ok($"{nameof(products)} updated successfully!");
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _orderService.DeleteAsync(id);

            return Ok();
        }
    }
}
