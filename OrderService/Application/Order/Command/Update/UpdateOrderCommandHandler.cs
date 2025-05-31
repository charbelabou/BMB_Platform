using MediatR;
using Persistance;

namespace Application.Order.Command.Update;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
{
    private readonly OrderDbContext _context;

    public UpdateOrderCommandHandler(OrderDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FindAsync(new object[] { request.Id }, cancellationToken);
        if (order == null)
        {
            throw new Exception("Order not found");
        }
        order.ProductId = request.ProductId;
        order.Quantity = request.Quantity;
        order.Total = request.Total;
        order.ClientId = request.ClientId;
        order.OrderDate = request.OrderDate;

        _context.Orders.Update(order);
        await _context.SaveChangesAsync(cancellationToken);
    }
}