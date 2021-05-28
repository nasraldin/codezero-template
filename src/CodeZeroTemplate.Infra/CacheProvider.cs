using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace CodeZeroTemplate.Infra
{
    public class CacheProvider : ICacheProvider
    {
        private readonly IDistributedCache _cache;

        public CacheProvider(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetFromCache<T>(string key) where T : class
        {
            var cachedUsers = await _cache.GetStringAsync(key);
#pragma warning disable CS8603 // Possible null reference return.
            return cachedUsers == null ? null : JsonSerializer.Deserialize<T>(cachedUsers);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task SetCache<T>(string key, T value, DistributedCacheEntryOptions options) where T : class
        {
            var users = JsonSerializer.Serialize(value);
            await _cache.SetStringAsync(key, users, options);
        }

        public async Task ClearCache(string key)
        {
            await _cache.RemoveAsync(key);
        }
    }
}