using MediatR;
using Persistance;

namespace Application.Product.Command.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly ProductDbContext _context;

    public DeleteProductCommandHandler(ProductDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(new object[] { request.Id }, cancellationToken);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
    }
}