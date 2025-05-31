using Application.DTO.Response;
using Application.Order.Command.Add;
using Application.Order.Command.Delete;
using Application.Order.Command.Update;
using Application.Order.Query.Get;
using Application.Order.Query.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAll()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            var orderDto = await _mediator.Send(new GetOrderByIdQuery { Id = id });
            return Ok(orderDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AddOrderCommand command)
        {
            var newOrderId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = newOrderId }, new { Id = newOrderId });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateOrderCommand command)
        {
            //i added this to show you both ways, either add validation or create a specific dto 
            if (id != command.Id)
            {
                return BadRequest("Mismatch between route ID and body ID");
            }

            await _mediator.Send(command);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteOrderCommand { Id = id });
            return NoContent();
        }
    }
}
