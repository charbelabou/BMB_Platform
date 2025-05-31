using MediatR;
using Persistance;

namespace Application.Product.Command.Add;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand,int>
{
    private readonly ProductDbContext _context;

    public AddProductCommandHandler(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Domain.Product
        {
            Name = request.Name,
            Price = request.Price
        };
        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product.Id;
    }
}