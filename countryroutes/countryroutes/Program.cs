var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

var countries = new Dictionary<int, string>
{
    {1,"USA"},
    {2,"Canada"},
    {3,"United kingdom"},
    {4, "India"},
    {5, "Japan"}
};

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("countries/{id:int:range(1,100)}", async context =>
    {
        int id = Convert.ToInt32(context.Request.RouteValues["id"]);
        if (countries.ContainsKey(id))
        {
            await context.Response.WriteAsync(countries[id]);
        }
        else
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("Country not found");
        }
    });
    endpoints.MapGet("countries/{id}", async context =>
    {
        await context.Response.WriteAsync("The country Id should be between 1 and 100");
    });
    endpoints.MapGet("countries", async context =>
    {
        var key = countries.Keys;
        foreach (int i in key)
        {
            await context.Response.WriteAsync($"{i} : {countries[i]} \n");
        }
    });
});

app.MapGet("/", () => "Hello World!");

app.Run();
