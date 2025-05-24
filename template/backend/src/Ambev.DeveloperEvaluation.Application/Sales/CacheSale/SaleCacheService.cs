using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Domain.Services;

public class SaleCacheService : CacheServiceBase<SaleCacheService, Sale>, ISaleCacheService<Sale>
{
    public SaleCacheService(IDistributedCache cache, ILogger<SaleCacheService> logger)
        : base(cache, logger)
    {
    }

    public Task<Sale?> GetCacheAsync(Guid id, CancellationToken cancellationToken)
        => base.GetCacheAsync($"sale-{id}", cancellationToken);

    public Task SetCacheAsync(Sale obj, CancellationToken cancellationToken, int expirationMin = 10)
        => base.SetCacheAsync($"sale-{obj.Id}", obj, cancellationToken, expirationMin);
}
