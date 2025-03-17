namespace middleware
{
    public class custommiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("<h2>custome middleware: starts</h2>");
            await next(context);
            await context.Response.WriteAsync("<h2>custome middleware: ends</h2>");
        }

    }
}