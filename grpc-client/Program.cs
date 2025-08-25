using System;
using Grpc.Core;
using Grpc.Net.Client;
using OrderProto;

var serverAddress = Environment.GetEnvironmentVariable("GRPC_SERVER") ?? "http://localhost:5075";

using var channel = GrpcChannel.ForAddress(serverAddress);
var client = new OrderService.OrderServiceClient(channel);

var reply = await client.PlaceOrderAsync(new PlaceOrderRequest
{
    CustomerId = "C-1001",
    Sku = "SKU-ABC",
    Quantity = 2
});

Console.WriteLine($"Order accepted: {reply.OrderId} ({reply.Status})");

using var call = client.SubscribeOrderStatus(new OrderStatusRequest { OrderId = reply.OrderId });

await foreach (var update in call.ResponseStream.ReadAllAsync())
{
    Console.WriteLine($"[{update.OrderId}] {update.Stage} ({update.Progress}%)");
}
