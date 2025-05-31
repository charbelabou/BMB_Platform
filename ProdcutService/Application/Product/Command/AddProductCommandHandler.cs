using MediatR;
using Persistance;


namespace Application.Product.Command;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand>
{
    private readonly ProductDbContext _context;

    public AddProductCommandHandler(ProductDbContext context)
    {
        _context = context;
    }

    public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        _context.Products.Add(new Domain.Product()
        {
            Name = request.Name,
            Price = request.Price
        });
        await _context.SaveChangesAsync(cancellationToken);
    }
}