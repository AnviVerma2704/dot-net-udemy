using LoginAssignment;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<login>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync("<h1>Welcome</h1>");
    await next(context);
});

//app.UseMiddleware<login>();
app.UseMiddleware();

app.Run();
