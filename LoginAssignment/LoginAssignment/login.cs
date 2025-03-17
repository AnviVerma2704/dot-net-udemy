
namespace LoginAssignment
{
    public class login : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var email = context.Request.Query["email"];
            var password = context.Request.Query["password"];
            //await context.Response.WriteAsync("<h3>Email: " + email + "</h3>");
            //await context.Response.WriteAsync("<h3>Password: " + password + "</h3>");
            if (email == "admin@example.com" && password == "admin1234")
            {
                await context.Response.WriteAsync("<h1>Successful login</h1>");
            }
            else
            {
                await context.Response.WriteAsync("<h1>Invalid Login</h1>");
            }
        }
    }
}
