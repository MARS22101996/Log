using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LoggingProj.Log.Module
{
    public class LoggingMiddlewareService
    {
        private const string CorrelationIdContextName = "CorrelationId";

        private readonly RequestDelegate _next;

        public LoggingMiddlewareService(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Items[CorrelationIdContextName] = context.Request.Headers[CorrelationIdContextName];

            context.Response.Headers.Add(CorrelationIdContextName, context.Items[CorrelationIdContextName].ToString());

            await _next(context);
        }
    }
}