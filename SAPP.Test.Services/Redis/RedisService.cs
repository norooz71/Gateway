using Microsoft.Extensions.Caching.Distributed;
using SAPP.Gateway.Services.Abstractions.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SAPP.Gateway.Services.Redis
{
    public class RedisService : IRedisService
    {
        private readonly IDistributedCache _redis;

        public RedisService(IDistributedCache redis)
        {
            _redis = redis; 
        }

        public async Task Create<T>(string key, T value, int duration)
        {
            var content=Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value));

            await _redis.SetAsync(key, content,new DistributedCacheEntryOptions {SlidingExpiration=TimeSpan.FromMinutes(duration) });

        }

        public async Task Delete(string key)
        {
           await _redis.RemoveAsync(key);
                        
        }

        public async Task<T> GetByKey<T>(string key)
        {
            var content=await _redis.GetStringAsync(key);

            return JsonSerializer.Deserialize<T>(content);
        }

        public async Task<IEnumerable<T>> GetAllByKey<T>(string key)
        {
            var content=await _redis.GetStringAsync(key);

            return JsonSerializer.Deserialize<IEnumerable<T>>(content);
        }
    }
}
