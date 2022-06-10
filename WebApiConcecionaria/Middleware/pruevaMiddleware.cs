namespace WebApiConcecionaria.Middleware
{ 
	public class pruevaMiddleware
	{
		private readonly RequestDelegate _next;

		public pruevaMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			await _next(context);
		}
	}
	
}
