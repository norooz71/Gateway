using SAPP.Gateway.Contracts.Utilities.ServiceCall;
using SAPP.Gateway.Services.Abstractions.Dtos.Test;
using SAPP.Gateway.Services.Abstractions.Dtos.RoutingDecide;

namespace SAPP.Gateway.Web.Middlewares
{
    public class RoutingDecideMiddleware : IMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceCall _serviceCall;


        public RoutingDecideMiddleware(RequestDelegate next, IServiceCall serviceCall)
        {
            _next = next;
            _serviceCall = serviceCall;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var input = new ComunicatedInputDto
            {
                HttpAuthenticationContext=context,
            };
            var callResult = await _serviceCall.Post<TestChildDto, ComunicatedInputDto>("", input, new KeyValuePair<string, string>());
            await _next(context);
        }
    }
}
