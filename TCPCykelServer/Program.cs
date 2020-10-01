using System;

namespace TCPCykelServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server svr = new Server();
            svr.Start();

            Console.ReadLine();
        }
    }
}
