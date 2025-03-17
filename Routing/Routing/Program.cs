var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("map1", async (context) =>
    {
        await context.Response.WriteAsync("Map1");
    });

    endpoints.MapPost("map2", async (context) =>
    {
        await context.Response.WriteAsync("Map2");
    });

    endpoints.Map("products/details/{id:int?}", async context =>
    {
        if (context.Request.RouteValues.ContainsKey("id"))
        {
            int id = Convert.ToInt32(context.Request.RouteValues["id"]);
            await context.Response.WriteAsync($"Products details - {id}");
        }
        else
        {
            await context.Response.WriteAsync($"Products details - id is not supplied");
        }
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello World!");
});

app.Run();
