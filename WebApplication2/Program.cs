var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

app.Run(async (HttpContext context)=>{
    int a = 0;
    int b = 0;
    string op = null;
    int result = 0;
    if (context.Request.Query.ContainsKey("a") && context.Request.Query.ContainsKey("b") && context.Request.Query.ContainsKey("op"))
    {
        a = int.Parse(context.Request.Query["a"]);
        b = int.Parse(context.Request.Query["b"]);
        op = context.Request.Query["op"];
        switch (op)
        {
            case "add":
                result = a + b;
                break;
            case "sub":
                result = a - b;
                break;
            case "mul":
                result = a * b;
                break;
            case "div":
                result = a / b;
                break;
            default:
                break;
        }
        await context.Response.WriteAsync($"Result: {result}");
    }
    else
    {
        await context.Response.WriteAsync("Invalid input");
    }
});
app.Run();