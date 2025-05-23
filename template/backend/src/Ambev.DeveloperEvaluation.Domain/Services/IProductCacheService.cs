namespace Ambev.DeveloperEvaluation.Domain.Services;

public interface IProductCacheService<Product> : ICacheService<Product>
{
    Task<Product?> GetCacheAsync(Guid id, CancellationToken cancellationToken);
    Task SetCacheAsync(Product obj, CancellationToken cancellationToken, int expirationMin = 10);
}