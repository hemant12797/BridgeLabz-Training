var builder = WebApplication.CreateBuilder(args);

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Load YARP routing config
builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

// Enable Swagger UI at Gateway level
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/user-swagger/v1/swagger.json", "User Management API");
    c.SwaggerEndpoint("/notes-swagger/v1/swagger.json", "Notes Management API");
    c.SwaggerEndpoint("/label-swagger/v1/swagger.json", "Label Management API");
    c.RoutePrefix = "swagger"; // Expose Swagger at http://localhost:7000/swagger
});

app.MapReverseProxy();

app.Run();
