using Newtonsoft.Json;
using SAPP.Gateway.Contracts.Utilities.ServiceCall;
using SAPP.Gateway.Services.Abstractions.Dtos.RoutingDecide;
using SAPP.Gateway.Services.Abstractions.Redis;
using System.Linq;

namespace SAPP.Gateway.Web.Middlewares;

public class RoutingDecideMiddleware
{
    private readonly RequestDelegate _next;

    public RoutingDecideMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context, IRedisService redis, IConfiguration configuration)
    {
        //1-Get request token 

        var token = context.Request.Headers.Authorization;

        //2-Get value of redis by token 

        var userRedisValue = await redis.GetByKey<UserAuthData>(token);

        //3-check csrf

        var csrfHeader = context.Request.Headers["CSRFToken"];

        if (userRedisValue.CSRF.Any(c=>c==csrfHeader))
        {
            userRedisValue.CSRF.ToList().Remove(csrfHeader);
        }

        var updatedUserAuthValue = new UserAuthData
        {
            CSRF = userRedisValue.CSRF,
            User=userRedisValue.User
        };

        await redis.Create(token, updatedUserAuthValue, 10);


        //4-update redis(pop csrf from csrf keys)



        //5-clean user data header and attach new user data header





        /*var request = context.Request;

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

        await _next(context);*/
    }
}



