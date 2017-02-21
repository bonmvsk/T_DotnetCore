using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Web03
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class RequestLoggerMiddleware
	{
		private readonly ILogger<RequestLoggerMiddleware> _logger;
		private readonly RequestDelegate _next;

		public RequestLoggerMiddleware(RequestDelegate next, ILoggerFactory logger)
		{
			_next = next;
			_logger = logger.CreateLogger<RequestLoggerMiddleware>();
		}

		public async Task Invoke(HttpContext httpContext)
		{
			_logger.LogInformation($"Started: {httpContext.Request.Path}");
			await _next?.Invoke(httpContext);
			_logger.LogInformation($"Finnished: {httpContext.Request.Path}");
		}
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class RequestLoggerMiddlewareExtensions
	{
		public static IApplicationBuilder UseRequestLoggerMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<RequestLoggerMiddleware>();
		}
	}
}
