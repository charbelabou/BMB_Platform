
namespace Infrastructure.Contracts;

public interface IProductService
{
    Task<bool> ProductExistsAsync(int productId, CancellationToken cancellationToken = default);
}
