using Application.DTO;
using Application.DTO.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Product.Query.GetAll;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    private readonly ProductDbContext _context;

    public GetAllProductsQueryHandler(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price
        }).ToList();
    }
}