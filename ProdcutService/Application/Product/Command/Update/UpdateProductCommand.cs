using MediatR;

namespace Application.Product.Command.Update;

public class UpdateProductCommand : IRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public float Price { get; set; }
}