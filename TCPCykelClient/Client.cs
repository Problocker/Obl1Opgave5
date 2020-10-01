using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using CykelModelLib.model;
using Newtonsoft.Json;

namespace TCPCykelClient
{
    public class Client
    {
        public void Start()
        {
            //"localhost"
            TcpClient socket = new TcpClient("localhost", 4646);

            StreamReader sr = new StreamReader(socket.GetStream());
            StreamWriter sw = new StreamWriter(socket.GetStream());

            //Cykel-IDer fra 1-10 er optaget i listen i Serverklassen
            Cykel cykler = new Cykel(69, "Platin", 999999, 32);
            String json = JsonConvert.SerializeObject(cykler);


            sw.WriteLine("Gem");
            sw.WriteLine(json);
            
            sw.Flush();

            socket.Close();
        }
    }
}
