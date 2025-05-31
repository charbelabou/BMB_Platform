using MediatR;
namespace Application.Product.Command;

public class AddProductCommand : IRequest
{
    public required string Name { get; set; }
    public float Price { get; set; }
}