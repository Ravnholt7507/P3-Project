using System;
using System.Net;
using System.Threading.Tasks;

namespace Project
{
    public class ServerStart
    {
        public void Start()
        {
            // Create a Http server and start listening for incoming connections
            Server.listener = new HttpListener();
            Server.listener.Prefixes.Add(Server.url);
            Server.listener.Start();
            Console.WriteLine("Listening for connections in your mamas ass {0}", Server.url);

            // Handle requests
            Task listenTask = Server.HandleIncomingConnections();
            listenTask.GetAwaiter().GetResult();

            // Close the listener
            Server.listener.Close();
        }
    }
}