using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;
using middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<custommiddleware>();

var app = builder.Build();

app.Use(async (context, next)=>{
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync("<h1>Middleware 1</h1>");
    await next(context);
    await context.Response.WriteAsync("<h1>Back to Middleware 1</h1>");
});

app.UseMiddleware<custommiddleware>();

app.UseWhen(context => context.Request.Query.ContainsKey("name"), 
    app =>
{
    app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("<h2>Branch Middleware</h2>");
        await next();
        await context.Response.WriteAsync("<h2>Back to Branch Middleware</h2>");
    });
});

app.Run(async (HttpContext context)=>{
    //context.Response.ContentType = "text/html";
    await context.Response.WriteAsync("<h2>Middleware 2</h2>");
});

app.Run();
