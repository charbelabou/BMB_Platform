using MediatR;
using Persistance;
using Application.DTO.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Order.Query.Get
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly OrderDbContext _context;
        private readonly ILogger<GetOrderByIdQueryHandler> _logger;

        public GetOrderByIdQueryHandler(OrderDbContext context, ILogger<GetOrderByIdQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            _logger.LogInformation("Order found with Id {OrderId}", request.Id);

            return new OrderDto
            {
                Id = order.Id,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                Total = order.Total,
                ClientId = order.ClientId,
                OrderDate = order.OrderDate
            };
        }
    }
}