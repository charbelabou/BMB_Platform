using MediatR;
using Persistance;

namespace Application.Order.Command.Delete
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly OrderDbContext _context;

        public DeleteOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FindAsync(new object[] { request.Id }, cancellationToken);
            if (order == null)
            {
                throw new Exception("Order not found");
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}