using SignalR.Service.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .WithOrigins("http://localhost:3000")
              .AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors("ClientPermission");
app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.MapHub<SignalHub>("/hubs/signalHub");
app.Run();
