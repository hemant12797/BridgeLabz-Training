using System.Text.Json;
using StackExchange.Redis;
using FundooNotes.Service.Interface;

namespace FundooNotes.Service.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDatabase _cache;

        public CacheService(IConnectionMultiplexer redis)
        {
            _cache = redis.GetDatabase();
        }

        // Get value from cache
        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await _cache.StringGetAsync(key);
            if (value.IsNullOrEmpty) return default;
            return JsonSerializer.Deserialize<T>((string)value!);
        }

        // Set value in cache with expiry
        public async Task SetAsync<T>(string key, T value, TimeSpan expiry)
        {
            var json = JsonSerializer.Serialize(value);
            await _cache.StringSetAsync(key, json, expiry);
        }

        // Remove a key from cache
        public async Task RemoveAsync(string key)
        {
            await _cache.KeyDeleteAsync(key);
        }
    }
}
