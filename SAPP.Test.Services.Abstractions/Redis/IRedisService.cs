using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPP.Gateway.Services.Abstractions.Redis
{
    public interface IRedisService
    {
        Task<T> GetByKey<T>(string key);

        Task Create<T>(string key,T value,int duration);

        Task Delete(string key);

        Task<IEnumerable<T>> GetAllByKey<T>(string key);

    }
}
