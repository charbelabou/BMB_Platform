using MediatR;

namespace Application.Product.Command.Delete;

public class DeleteProductCommand : IRequest
{
    public int Id { get; set; }
}