namespace Ambev.DeveloperEvaluation.Domain.Services;

public interface ISaleCacheService<Sale> : ICacheService<Sale>
{
    Task<Sale?> GetCacheAsync(Guid id, CancellationToken cancellationToken);
    Task SetCacheAsync(Sale obj, CancellationToken cancellationToken, int expirationMin = 10);
}