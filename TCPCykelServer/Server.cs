using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CykelModelLib.model;
using Newtonsoft.Json;

namespace TCPCykelServer
{
    class Server
    {
        //Laver listen af cykler.
        private static readonly List<Cykel> cykler = new List<Cykel>()
        {
            new Cykel(1, "Carbon", 99995.95, 22),
            new Cykel(2, "Limegrøn", 4795.65, 6),
            new Cykel(3, "Marineblå", 12000, 36),
            new Cykel(4, "Bordeauxrød", 1200, 3),
            new Cykel(5, "Citrongul", 18000, 12),
            new Cykel(6, "Frederiksberg-grøn", 4269, 18),
            new Cykel(7, "Pantone Maersk Blue", 87865, 32),
            new Cykel(8, "Ridderspore", 8888, 14),
            new Cykel(9, "Hvid", 27000, 9),
            new Cykel(10, "Kongeblå", 7769.42, 15)
        };

        public void Start()
        {
            //Opretter server.
            TcpListener server = new TcpListener(IPAddress.Loopback, 4646);
            server.Start();

            while (true)
            {
                //Venter på at klienten skal lave et opkld. 
                TcpClient socket = server.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient tempSocket = socket;
                    DoClient(tempSocket);
                });
            }

        }

        public void DoClient(TcpClient socket)
        {
            StreamReader sr = new StreamReader(socket.GetStream());
            StreamWriter sw = new StreamWriter(socket.GetStream());

            String str = sr.ReadLine();
            Console.WriteLine($"Her er server input: {str}");

            if (str == "HentAlle")
            {
                sw.WriteLine($" Her er cykellisten: ");
                Console.WriteLine($"Cykel i listen: ");
                foreach (var cykelList in cykler) sw.WriteLine(cykelList);
                foreach (var cykelList in cykler)
                {
                    Console.WriteLine(cykelList);
                }
            }
            else if (str == "Hent")
            {
                Console.WriteLine($"Skriv ID på cykel.: ");
                sw.WriteLine("Skriv ID: ");

                sw.Flush();

                string str2;
                str2 = sr.ReadLine();
                var i = int.Parse(str2);
                var c = cykler.FirstOrDefault(cykelList => cykelList.Id == i);

                sw.WriteLine(c);
                Console.WriteLine(c);
            }
            else if (str == "Gem")
            {
                string str3;
                str3 = sr.ReadLine();
                Cykel cyklen = JsonConvert.DeserializeObject<Cykel>(str3);

                Console.WriteLine("Gemmer Cykel: " + cyklen);
                Console.WriteLine("Gemmer Cykel som json string: " + str3);
                sw.WriteLine("Modtager cykel: " + str3);
            }
            sw.Flush();
        }
        }

    }

