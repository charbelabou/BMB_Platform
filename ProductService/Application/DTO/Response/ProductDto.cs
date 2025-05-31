namespace Application.DTO.Response;

public class ProductDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public float Price { get; set; }
}