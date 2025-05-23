using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Domain.Services;

public class ProductCacheService : CacheServiceBase<ProductCacheService, Product>, IProductCacheService<Product>
{
    public ProductCacheService(IDistributedCache cache, ILogger<ProductCacheService> logger)
        : base(cache, logger)
    {
    }

    public Task<Product?> GetCacheAsync(Guid id, CancellationToken cancellationToken)
        => base.GetCacheAsync($"product-{id}", cancellationToken);

    public Task SetCacheAsync(Product obj, CancellationToken cancellationToken, int expirationMin = 10)
        => base.SetCacheAsync($"product-{obj.Id}", obj, cancellationToken, expirationMin);
}
