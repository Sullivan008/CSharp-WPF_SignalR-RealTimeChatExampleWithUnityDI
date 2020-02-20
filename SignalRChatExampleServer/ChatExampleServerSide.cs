using Microsoft.Owin.Hosting;
using SignalRChatExampleServer.Configurations;
using System;

namespace SignalRChatExampleServer
{
    public class ChatExampleServerSide
    {
        private static void Main(string[] args)
        {
            const string hostUrl = "http://localhost:8080/";

            using (WebApp.Start<Startup>(hostUrl))
            {
                Console.Write($"The server is running at the following address: {hostUrl}\n\n");
                Console.ReadLine();
            }
        }
    }
}
