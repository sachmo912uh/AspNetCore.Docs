﻿#region snippet2
using System;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;

namespace GrpcGreeterClient
{
    class Program
    {
        #region snippet
        static async Task Main(string[] args)
        {
            // The port number(50051) must match the port of the gRPC server.
            var channel = new Channel("localhost:50051", 
                                       ChannelCredentials.Insecure);
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
            await channel.ShutdownAsync();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        #endregion
    }
}
#endregion
