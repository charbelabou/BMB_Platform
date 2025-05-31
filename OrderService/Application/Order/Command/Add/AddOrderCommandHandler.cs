using Infrastructure.Contracts;
using MediatR;
using Persistance;


namespace Application.Order.Command.Add
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, int>
    {
        private readonly OrderDbContext _context;
        private readonly IProductService _productService;

        public AddOrderCommandHandler(OrderDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        public async Task<int> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var exists = await _productService.ProductExistsAsync(request.ProductId, cancellationToken);
            if (!exists)
                throw new Exception("Product does not exist");

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