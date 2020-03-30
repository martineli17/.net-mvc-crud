using Crosscuting.Notification;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Apresentation.Configurations
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var exception = ex;
            }
        }
    }
}
