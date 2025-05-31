using MediatR;
using Persistance;
using Application.DTO.Response;
using Microsoft.EntityFrameworkCore;

namespace Application.Order.Query.GetAll
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
    {
        private readonly OrderDbContext _context;

        public GetAllOrdersQueryHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return orders.Select(o => new OrderDto
            {
                Id = o.Id,
                ProductId = o.ProductId,
                Quantity = o.Quantity,
                Total = o.Total,
                ClientId = o.ClientId,
                OrderDate = o.OrderDate
            }).ToList();
        }
    }
}