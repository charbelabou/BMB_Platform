using Application.DTO;
using Application.DTO.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Product.Query.Get;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly ProductDbContext _context;

    public GetProductByIdQueryHandler(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (product == null)
        {
            return null!; // Or throw exception / handle as desired
        }

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }
}