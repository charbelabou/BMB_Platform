using MediatR;
using Application.DTO.Response;

namespace Application.Order.Query.Get
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public int Id { get; set; }
    }
}