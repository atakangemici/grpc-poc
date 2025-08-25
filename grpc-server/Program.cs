using Server.Services;

var builder = WebApplication.CreateBuilder(args);

// gRPC
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<OrderServiceImpl>();
app.MapGet("/", () => "gRPC server is running.");

app.Run();
