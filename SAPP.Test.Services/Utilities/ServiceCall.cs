using Microsoft.Extensions.Configuration;
using RestSharp;
using SAPP.Gateway.Contracts.Utilities.ServiceCall;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoaFounding.Infrastructure.ExternalServices
{
    internal class ExternalServiceCall : IServiceCall
    {
        private readonly RestClient _restClient;
        private readonly string _baseUrl;

        public ExternalServiceCall(RestClient restClient, IConfiguration configuration)
        {
            _restClient = restClient;
            _baseUrl = configuration.GetSection("Sms:Url").Value;
        }

        public async Task<T> Get<T, U>(string url, U input, params KeyValuePair<string, string>[] headers)
        {
            if (input != null)
            {
                url += "?";
                foreach (var property in input.GetType().GetProperties())
                    url += property.Name + "=" + property.GetValue(input) + "&&";
            }

            var request = new RestRequest($"{_baseUrl}/{url}", Method.Get);

            foreach (var header in headers)
                request.AddHeader(header.Key, header.Value);

            var restResponse = await _restClient.ExecuteAsync<T>(request);

            if (restResponse.IsSuccessful)
                return restResponse.Data;
            throw new NullReferenceException(restResponse.ErrorMessage, null);
        }

        public async Task<T> Post<T, U>(string url, U input, params KeyValuePair<string, string>[] headers)
        {
            var request = new RestRequest($"{_baseUrl}/{url}", Method.Post);

            foreach (var header in headers)
                request.AddHeader(header.Key, header.Value);

            request.AddBody(input);

            var restResponse = await _restClient.ExecuteAsync<T>(request);

            if (restResponse.IsSuccessful)
                return restResponse.Data;
            throw new NullReferenceException(restResponse.ErrorMessage, null);
        }
    }
}
