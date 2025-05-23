using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Ambev.DeveloperEvaluation.Domain.Services;

public abstract class CacheServiceBase<T, O> where T : CacheServiceBase<T, O>, ICacheService<O>
{
    protected readonly IDistributedCache _cache;
    protected readonly ILogger<T> _logger;

    protected CacheServiceBase(IDistributedCache cache, ILogger<T> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public virtual async Task<O?> GetCacheAsync(string key, CancellationToken cancellationToken)
    {
        try
        {
            var cached = await _cache.GetStringAsync(key, cancellationToken);
            var deserialized = JsonSerializer.Deserialize<O>(cached);
            _logger.LogInformation("Cache retrieved with key {Key} {cached}", key, cached);
            return string.IsNullOrWhiteSpace(cached) ? default : deserialized;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error reading cache with key {Key}", key);
            return default;
        }
    }

    public virtual async Task SetCacheAsync(string key, O obj, CancellationToken cancellationToken, int expirationMin = 10)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(expirationMin)
        };

        try
        {
            var json = JsonSerializer.Serialize(obj);
            await _cache.SetStringAsync(key, json, options, cancellationToken);
            _logger.LogInformation("Cache saved with key {Key}", key);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving cache with key {Key}", key);
        }
    }
}
