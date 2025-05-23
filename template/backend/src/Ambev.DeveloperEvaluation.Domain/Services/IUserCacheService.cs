namespace Ambev.DeveloperEvaluation.Domain.Services;

public interface IUserCacheService<User> : ICacheService<User>
{
    Task<User?> GetCacheAsync(Guid id, CancellationToken cancellationToken);
    Task SetCacheAsync(User obj, CancellationToken cancellationToken, int expirationMin = 10);
}