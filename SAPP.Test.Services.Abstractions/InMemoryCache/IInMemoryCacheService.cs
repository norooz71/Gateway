using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPP.Gateway.Services.Abstractions.InMemoryCache
{
    public interface IInMemoryCacheService
    {
        T GetByKey<T>(string key);

        void Create<T>(string key, T value, int duration);

        void Delete(string key);

    }
}
