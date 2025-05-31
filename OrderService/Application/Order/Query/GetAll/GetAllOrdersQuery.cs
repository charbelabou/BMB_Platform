using MediatR;
using Application.DTO.Response;

namespace Application.Order.Query.GetAll
{
    public class GetAllOrdersQuery : IRequest<List<OrderDto>>
    {
    }
}