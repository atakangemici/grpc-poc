using Grpc.Core;
using OrderProto;

namespace Server.Services;

public class OrderServiceImpl : OrderService.OrderServiceBase
{
    public override Task<PlaceOrderReply> PlaceOrder(PlaceOrderRequest request, ServerCallContext context)
    {
        var orderId = Guid.NewGuid().ToString("N");
        return Task.FromResult(new PlaceOrderReply
        {
            OrderId = orderId,
            Status = "ACCEPTED"
        });
    }

    public override async Task SubscribeOrderStatus(OrderStatusRequest request, IServerStreamWriter<OrderStatusUpdate> responseStream, ServerCallContext context)
    {
        var stages = new (string stage, int progress)[] {
            ("PACKING", 10), ("LABELING", 30), ("IN_TRANSIT", 70), ("OUT_FOR_DELIVERY", 90), ("DELIVERED", 100)
        };

        foreach (var (stage, progress) in stages)
        {
            await responseStream.WriteAsync(new OrderStatusUpdate
            {
                OrderId = request.OrderId,
                Stage = stage,
                Progress = progress
            });

            await Task.Delay(1000, context.CancellationToken);
        }
    }
}
