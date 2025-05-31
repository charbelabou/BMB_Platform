using Application.DTO;
using Application.DTO.Response;
using MediatR;

namespace Application.Product.Query.Get;

public class GetProductByIdQuery : IRequest<ProductDto>
{
    public int Id { get; set; }
}