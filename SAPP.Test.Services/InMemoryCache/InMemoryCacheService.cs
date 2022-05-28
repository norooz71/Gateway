using Microsoft.Extensions.Caching.Memory;
using SAPP.Gateway.Services.Abstractions.InMemoryCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SAPP.Gateway.Services.InMemoryCache
{
    public class InMemoryCacheService : IInMemoryCacheService
    {
        private readonly IMemoryCache _cache;

        public InMemoryCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }


        public void Create<T>(string key, T value, int duration)
        {
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions();
            options.AbsoluteExpiration = DateTime.Now.AddMinutes(duration);
            _cache.Set(key, value, options);
        }

        public void Delete(string key)
        {
            _cache.Remove(key);
        }

        public  T GetByKey<T>(string key)
        {
            return  _cache.Get<T>(key);
        }
    }
}
