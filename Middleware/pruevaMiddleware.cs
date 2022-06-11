
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class pruevaMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger logger;

		public pruevaMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			await _next(context);
		}
	}

	

