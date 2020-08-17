using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("log.txt", outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.Seq("http://192.168.1.200:5341/", apiKey : "cq1yUQGgrvyVKBJfnS9o")
                .CreateLogger();
        }

        public async Task Invoke(HttpContext context)
        {
            try{
                await _next(context);
            }
            finally
            {
                Log.Information("Request {Method} {Url} => {StatusCode}", context.Request.Method, context.Request.Path, context.Response.StatusCode);
            }
        }
    }
}
