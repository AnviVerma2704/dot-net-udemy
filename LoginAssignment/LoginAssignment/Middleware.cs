using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace LoginAssignment
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Query.ContainsKey("email") && context.Request.Query.ContainsKey("password")) {
                var email = context.Request.Query["email"];
                var password = context.Request.Query["password"];
                if (email == "admin@example.com" && password == "admin1234")
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("<h1>Successful login</h1>");
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("<h1>Invalid Login</h1>");
                    
                }
            }
            else {
                if (context.Request.Query.ContainsKey("email") || context.Request.Query.ContainsKey("password"))
                {
                    await context.Response.WriteAsync("<h3>Invalid input for 'password'</h3>");
                }
                else
                {
                    await context.Response.WriteAsync("<h3>Invalid input for 'email'</h3>");
                    await context.Response.WriteAsync("<h3>Invalid input for 'password'</h3>");
                }
            }
                await _next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
