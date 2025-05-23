using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Ambev.DeveloperEvaluation.Domain.Services;

public class UserCacheService : CacheServiceBase<UserCacheService, User>, IUserCacheService<User>
{
    public UserCacheService(IDistributedCache cache, ILogger<UserCacheService> logger)
        : base(cache, logger)
    {
    }

    public Task<User?> GetCacheAsync(Guid id, CancellationToken cancellationToken)
        => base.GetCacheAsync($"user-{id}", cancellationToken);

    public Task SetCacheAsync(User obj, CancellationToken cancellationToken, int expirationMin = 10)
        => base.SetCacheAsync($"user-{obj.Id}", obj, cancellationToken, expirationMin);
}
