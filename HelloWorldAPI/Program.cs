var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("api/v1", () => Results.Ok(new { message = "Hello World!" }))
    .WithName("GetHelloWorld");

app.Run();

public partial class Program {}