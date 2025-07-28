var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async context =>
{
    var path = context.Request.Path.ToString();
    var response = context.Response;
    var request = context.Request;
    
    response.ContentType = "text/plain";
    
    if (request.Path.StartsWithSegments("/api/length"))
    {
        await response.WriteAsync(path.Split("/").ElementAtOrDefault(3)?.Length.ToString() ?? "0");
    } else if (request.Path.StartsWithSegments("/api") && request.QueryString.ToString() != "")
    {
        await response.WriteAsync(request.QueryString.ToString().Remove(0, 1).Length.ToString());
    }
});
app.Run();