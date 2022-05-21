using Microsoft.AspNetCore.Http;
using SAPP.Gateway.Contracts.Utilities.Logger;
using SAPP.Gateway.Domain.Entities.Test;
using SAPP.Gateway.Domain.Exeptions;
using SAPP.Gateway.Presentation.Responses;

namespace SAPP.Gateway.Web.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
 
        }

        public async Task InvokeAsync(HttpContext _context, ILoggerManager logger)
        {
            try
            {
                await _next(_context);
            }
            catch (GlobalException ex)
            {
                logger.Error(ex.Message);

                _context.Response.ContentType = "application/json";
                _context.Response.StatusCode = _context.Response.StatusCode;


                var errorMessages = new List<string>();

                int statusCode = 0;

                switch (ex.Type)
                {
                    case ExceptionType.NotFound:
                        errorMessages.Add(ex.Message);
                        statusCode = 404;
                        break;

                    case ExceptionType.InvalidArgument:
                        errorMessages.Add(ex.Message);
                        statusCode = 400;
                        break;

                    default:
                        errorMessages.Add(ExceptionMessages.InternalError);
                        statusCode = 500;
                        break;
                }

                await _context.Response.WriteAsync(new BaseResponse<object>(true, statusCode, null, errorMessages).ToString());
            }

        }
    }

}
