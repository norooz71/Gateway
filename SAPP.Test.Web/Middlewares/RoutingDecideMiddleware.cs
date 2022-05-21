using Newtonsoft.Json;
using SAPP.Gateway.Contracts.Utilities.ServiceCall;
using SAPP.Gateway.Services.Abstractions.Dtos.RoutingDecide;

namespace SAPP.Gateway.Web.Middlewares;

public class RoutingDecideMiddleware
{
    private readonly RequestDelegate _next;

    public RoutingDecideMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context, IServiceCall serviceCall, IConfiguration configuration)
    {
        var request = context.Request;

        var authorization = request.Headers.Authorization;

        var json=JsonConvert.SerializeObject(new BaseResponse<ComunicatedResponse>(ServerAnswerEnum.TokenFailed, null, "invalid token parameter"));

        if (string.IsNullOrEmpty(authorization))
        {
            await context.Response.WriteAsync(json);
            return; 
        }

        if (authorization.ToString().Substring(0, 7) != "Bearer ")
        {
            await context.Response.WriteAsync(json);

            return;
        }
            

        var input = new ComunicatedInputDto
        {
            AuthHeader = context.Request.Headers.Authorization,
            CsrfTokenId = context.Request.Headers["CsrfTokenId"].FirstOrDefault(),
        };

        var url = configuration.GetSection("SaapUrl").Value + "api/v1/Comunication/GetCommunicatedResponse";

        var callResult = await serviceCall.Post<ComunicatedInputDto, BaseResponse<ComunicatedResponse>>(url, input);

        await _next(context);
    }
}


 
