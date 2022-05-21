using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using SAPP.Gateway.Contracts.Utilities.ServiceCall;
using SAPP.Gateway.Domain.Exeptions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NoaFounding.Infrastructure.ExternalServices;

public class ServiceCall : IServiceCall
{
    private readonly HttpClient _httpClient;

    public ServiceCall(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TResponse> Post<TRequest, TResponse>(string url, TRequest input,
        CancellationToken cancellationToken = default, params KeyValuePair<string, string>[] headers)
    {
        foreach (var header in headers)
            _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);

        var jsonData = JsonConvert.SerializeObject(input);
        var data = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var httpResponse = await _httpClient.PostAsync(url, data, cancellationToken);

        string response = string.Empty;

        if (httpResponse.IsSuccessStatusCode)
        {
            response = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
            return JsonConvert.DeserializeObject<TResponse>(response);
        }

        else
            throw new GlobalException(ExceptionLevel.Service,ExceptionType.ServiceCall ,"درخواست با خطا مواجه شده است.");
    }

}
