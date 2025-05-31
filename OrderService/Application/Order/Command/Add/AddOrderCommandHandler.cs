using MediatR;
using Persistance;


namespace Application.Order.Command.Add
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, int>
    {
        private readonly OrderDbContext _context;

        public AddOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Domain.Order
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Total = request.Total,
                ClientId = request.ClientId,
                OrderDate = request.OrderDate
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);
            return order.Id;
        }
    }
}