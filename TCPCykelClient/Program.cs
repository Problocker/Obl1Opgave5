using System;

namespace TCPCykelClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client cli = new Client();
            cli.Start();

            Console.ReadLine();
        }
    }
}
