namespace Application.DTO.Request;

public class UpdateProductRequestDto
{
    public required string Name { get; set; }
    public float Price { get; set; }
}