namespace WebApiConcecionaria.Middleware
{
    public class pruevaMiddleware
    {
    }

	namespace WebPersonal.BackEnd.API.Middlewares
	{

		public class EjemploMiddleware
		{
			private readonly RequestDelegate _next;

			public EjemploMiddleware(RequestDelegate next)
			{
				_next = next;
			}

			public async Task Invoke(HttpContext context)
			{
				await _next(context);
			}
		}
	}
}
