using Application.DTO;
using Application.DTO.Response;
using MediatR;

namespace Application.Product.Query.GetAll;

public class GetAllProductsQuery : IRequest<List<ProductDto>>
{
}