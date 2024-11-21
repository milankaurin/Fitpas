using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace Server
{
    public class Server
    {
        Socket socket;

        public Server()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            string ip = ConfigurationManager.AppSettings["ip"];
            int port = int.Parse(ConfigurationManager.AppSettings["port"]);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            socket.Bind(endPoint);
            socket.Listen(5);

            Thread thread = new Thread(AcceptClient);
            thread.Start();

        }

        public void AcceptClient()
        {
            try
            {
                while (true)
                {
                    Socket klijentskiSoket = socket.Accept();
                    ClientHandler handler = new ClientHandler(klijentskiSoket);
                    Thread klijentskaNit = new Thread(handler.HandleRequest);
                    klijentskaNit.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        public void Stop()
        {
            // Kreiranje privremene liste za bezbedno zatvaranje svih handlera
            var handlersToStop = Session.clientHandlers.ToList();

            foreach (var handler in handlersToStop)
            {
                handler.Stop(); // Zaustavljanje svakog ClientHandler-a
            }

            socket.Close();
            Session.clientHandlers.Clear(); // Čišćenje liste handler-a
        }

    }
}