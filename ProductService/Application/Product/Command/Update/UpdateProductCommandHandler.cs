using MediatR;
using Persistance;

namespace Application.Product.Command.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly ProductDbContext _context;

    public UpdateProductCommandHandler(ProductDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(new object[] { request.Id }, cancellationToken);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        product.Name = request.Name;
        product.Price = request.Price;

        _context.Products.Update(product);
        await _context.SaveChangesAsync(cancellationToken);
    }
}