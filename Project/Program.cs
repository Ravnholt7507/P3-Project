using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using Project;

namespace Project
{
    class HttpServer
    {
        public static void Main(string[] args)
        {
            ServerStart start = new ServerStart();
            start.Start();
        }
    }
}
