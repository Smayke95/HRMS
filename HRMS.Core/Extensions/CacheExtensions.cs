using Microsoft.Extensions.Caching.Memory;

namespace HRMS.Core.Extensions;

public static class CacheExtensions
{
    public static T GetOrAdd<T>(this IMemoryCache cache, string key, int seconds, Func<T> factory)
    {
        return cache.GetOrCreate(key, entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(seconds);
            return factory.Invoke();
        })!;
    }
}