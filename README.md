# gRPC Order Service PoC  

Bu repo, mikroservisler arasında **gerçek zamanlı iletişim** için gRPC’nin nasıl kullanılabileceğini gösteren bir **Proof of Concept (PoC)** uygulamasını içerir.  

## 🚀 Özellikler  
- **Unary RPC**: Tek istek–tek yanıt (PlaceOrder)  
- **Server Streaming RPC**: Tek istek–çok yanıt (SubscribeOrderStatus)  
- **Contract-first tip güvenliği**: `.proto` dosyası üzerinden client & server kod üretimi  
- **Gerçek zamanlı senaryo**: Sipariş oluşturma ve sipariş durumunun canlı takibi  

## 🛠️ Kurulum  
```bash
git clone https://github.com/kullanici/grpc-order-service.git
cd grpc-order-service
dotnet build
dotnet run
