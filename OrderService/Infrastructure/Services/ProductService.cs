

using Infrastructure.Configurations;
using Infrastructure.Contracts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ProductService> _logger;
    private readonly string _productBaseUrl;

    public ProductService(HttpClient httpClient, IOptions<ProductServiceSettings> settings, ILogger<ProductService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _productBaseUrl = settings.Value.BaseUrl.TrimEnd('/');
    }

    public async Task<bool> ProductExistsAsync(int productId, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_productBaseUrl}/products/{productId}", cancellationToken);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while calling ProductService");
            return false;
        }
    }
}