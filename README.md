# gRPC Order Service PoC  

This repository demonstrates how to use **gRPC for real-time communication** between microservices with a simple **Proof of Concept (PoC)** application.  

## 🚀 Features  
- **Unary RPC**: Single request – single response (PlaceOrder)  
- **Server Streaming RPC**: Single request – multiple responses (SubscribeOrderStatus)  
- **Contract-first type safety**: Client & server code generated from `.proto` file  
- **Real-time scenario**: Place an order and track its status live  

## 🛠️ Setup  
After cloning the project, follow these steps:  

```bash
# Clone the repository
git clone https://github.com/username/grpc-order-service.git

# Navigate into the project folder
cd grpc-order-service

# Build the project
dotnet build

# Run the project
dotnet run
