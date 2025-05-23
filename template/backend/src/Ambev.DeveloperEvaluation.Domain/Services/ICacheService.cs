namespace Ambev.DeveloperEvaluation.Domain.Services;

public interface ICacheService<O>
{
    Task<O?> GetCacheAsync(string key, CancellationToken cancellationToken);
    Task SetCacheAsync(string key, O obj, CancellationToken cancellationToken, int expirationMin = 10);
}
