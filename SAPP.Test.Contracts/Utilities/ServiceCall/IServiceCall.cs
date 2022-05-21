using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SAPP.Gateway.Contracts.Utilities.ServiceCall
{
    public interface IServiceCall
    {
        /* Task<T> Get<T, U>(string url, U input, params KeyValuePair<string, string>[] headers);

         Task<T> Post<T, U>(string url, U input, params KeyValuePair<string, string>[] headers);*/

        Task<TResponse> Post<TRequest, TResponse>(string url, TRequest input,
            CancellationToken cancellationToken = default, params KeyValuePair<string, string>[] headers);
    }
}
