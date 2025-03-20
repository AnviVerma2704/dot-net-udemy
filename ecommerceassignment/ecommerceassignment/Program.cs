var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();  
var app = builder.Build();

app.UseStaticFiles();
app.UseRouter();
app.UseEndpoints();

//app.MapGet("/", () => "Hello World!");

app.Run();
