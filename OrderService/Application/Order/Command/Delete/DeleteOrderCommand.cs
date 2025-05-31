using MediatR;

namespace Application.Order.Command.Delete
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }
    }
}