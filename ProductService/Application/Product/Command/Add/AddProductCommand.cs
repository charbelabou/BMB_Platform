using MediatR;

namespace Application.Product.Command.Add;

public class AddProductCommand : IRequest<int>
{
    public required string Name { get; set; }
    public float Price { get; set; }
}