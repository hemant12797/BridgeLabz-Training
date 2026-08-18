var builder = WebApplication.CreateBuilder(args);

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Assuming standard Angular port
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Configure YARP
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.UseCors("AllowFrontend");

app.MapGet("/", () => "Fundoo Notes API Gateway is running! Append /api/user/... to route requests to the User Management service.");

app.MapReverseProxy();

app.Run();
