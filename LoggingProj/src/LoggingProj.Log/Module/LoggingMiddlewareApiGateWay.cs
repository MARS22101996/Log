using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LoggingProj.Log.Module
{
    public class LoggingMiddlewareApiGateWay
    {
        private const string CorrelationIdContextName = "CorrelationId";

        private readonly RequestDelegate _next;

        public LoggingMiddlewareApiGateWay(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Items[CorrelationIdContextName] = Guid.NewGuid().ToString();

            context.Response.Headers.Add(CorrelationIdContextName, context.Items[CorrelationIdContextName].ToString());

            await _next(context);
        }
    }
}