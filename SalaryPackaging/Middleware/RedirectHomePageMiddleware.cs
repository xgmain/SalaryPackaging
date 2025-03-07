namespace SalaryPackaging.Middleware
{
    public class RedirectHomePageMiddleware
    {
        private readonly RequestDelegate _next;

        public RedirectHomePageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/")
            {
                context.Response.Redirect("/SalaryPackaging/");
                return;
            }

            await _next(context);
        }
    }
}
