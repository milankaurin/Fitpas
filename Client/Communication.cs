using Common;
using Common.CommunicationHelper;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Client
{
    public class Communication
    {
        public bool connected = false;
        Socket socket;
        Sender sender;
        Receiver receiver;

        private static Communication _instance;
        public static Communication Instance
        {
            get
            {
                if (_instance == null) { _instance = new Communication(); }

                return _instance;
            }
        }
        private Communication()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }



        public void Connect()
        {
            if (connected) // Ako je već povezan, vrati se da ne bi stvarao nove instance.
                return;

            try
            {
                socket?.Close(); // Oslobađa prethodni socket ako postoji.
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect("127.0.0.1", 9999);

                sender = new Sender(socket);
                receiver = new Receiver(socket);

                connected = true;
            }
            catch (SocketException ex)
            {
                connected = false; // Obezbediti da connected bude false ako se povezivanje ne uspe.
                throw new Exception("Cannot connect to the server. Please check your network connection: " + ex.Message);
            }
        }

        public void Disconnect()
        {
            if (socket != null)
            {
                if (socket.Connected)
                {
                    socket.Shutdown(SocketShutdown.Both);
                }
                socket?.Close();
                socket = null;
            }
            connected = false;
            sender = null;
            receiver = null; 
            
        }

        public void Send(Request req)
        {
            if (!connected) throw new InvalidOperationException("No connection to the server.");
            sender.Send(req);
        }
        public Response Receive()
        {
            Response response = (Response)receiver.Receive();
            if (response.Exception == null) return response;
            else
            {
                throw new Exception(response.Exception.Message);
            }
        }

        public void Close()
        {
            sender.Close();
            receiver.Close();
        }


        internal Response Login(User user)
        {
            Request req = new Request
            {
                Argument = user,
                Operation = Operation.Login
            };
            Send(req);
            Response response = (Response) receiver.Receive();
            return response;
        }
        internal Response KreirajKlijenta(Klijent klijent)
        {
            Request req = new Request
            {
                Argument = klijent,
                Operation = Operation.KreirajKlijenta
            };

            Send(req);
            Response response = Receive();
            return response;

        }
        internal int KreirajPaket(Paket paket)
        {
            Request req = new Request
            {
                Argument = paket,
                Operation = Operation.KreirajPaket
            };

            Send(req);
            Response response = Receive();
            return (int) response.Result;
        }
        internal int KreirajTeretanu(Teretana teretana)
        {
            Request req = new Request
            {
                Argument = teretana,
                Operation = Operation.KreirajTeretanu
            };

            Send(req);
            Response response = Receive();
            return (int) response.Result;
        }
        internal Kategorija KreirajKategoriju(Kategorija kategorija)
        {
            Request req = new Request
            {
                Argument = kategorija,
                Operation = Operation.KreirajKategoriju
            };

            Send(req);
            Response response = Receive();
            return response.Result as Kategorija;
        }

        public Response KreirajClanarinu(Clanarina clanarina)
        {
            Request request = new Request
            {
                Argument = clanarina,
                Operation = Operation.KreirajClanarinu
            };
            Send(request);
            Response response = Receive();
            return response;
        }



        public Response AzurirajKlijenta(Klijent klijent)
        {
            Request request = new Request();
            request.Argument = klijent;
            request.Operation=Operation.AzurirajKlijenta;
            Send(request);
            Response response = Receive();
            return response;
        }
        public Response AzurirajPaket(Paket paket)
        {
            Request request = new Request
            {
                Argument = paket,
                Operation = Operation.AzurirajPaket
            };
            Send(request);
            Response response = Receive();
            return response;
        }
        public Response AzurirajTeretanu(Teretana teretana)
        {
            Request request = new Request
            {
                Argument = teretana,
                Operation = Operation.AzurirajTeretanu
            };
            Send(request);
            Response response = Receive();
            return response;
        }
        public Response AzurirajKategoriju(Kategorija kategorija)
        {
            Request request = new Request
            {
                Argument = kategorija,
                Operation = Operation.AzurirajKategoriju
            };
            Send(request);
            Response response = Receive();
            return response;
        }
        public Response AzurirajClanarinu(Clanarina clanarina)
        {
            Request request = new Request
            {
                Argument = clanarina,
                Operation = Operation.AzurirajClanarinu
            };
            Send(request);
            Response response = Receive();
            return response;
        }


        internal Response ObrisiKlijenta(Klijent klijent)
        {
            Request request = new Request();
            request.Argument = klijent;
            request.Operation = Operation.ObrisiKlijenta;
            Send(request);
            Response response = Receive();
            return response;
        }
        internal Response ObrisiPaket(Paket paket)
        {
            Request request = new Request
            {
                Argument = paket,
                Operation = Operation.ObrisiPaket
            };
            Send(request);
            Response response = Receive();

            if (response.Exception != null)
            {
                throw new ApplicationException("Ne može se obrisati paket: " + response.Exception.Message);
            }

            return response;
        }

        internal Response ObrisiTeretanu(Teretana teretana)
        {
            Request request = new Request();
            request.Argument = teretana;
            request.Operation = Operation.ObrisiTeretanu;
            Send(request);
            Response response = Receive();
            return response;
        }
        internal Response ObrisiKategoriju(Kategorija kategorija)
        {
            Request request = new Request();
            request.Argument = kategorija;
            request.Operation = Operation.ObrisiKategoriju;
            Send(request);
            Response response = Receive();
            return response;
        }

        public List<Klijent> PretraziKlijente(string text)
        {
            Request request = new Request();
            request.Argument = text;
            request.Operation = Operation.NadjiKlijenta;
            Send(request);
            Response response = Receive();
            return response.Result as List<Klijent>;
        }

        public List<Clanarina> PretraziClanarine(string text)
        {
            Request request = new Request();
            request.Argument = text;
            request.Operation = Operation.PretraziClanarinu;
            Send(request);
            Response response = Receive();
            return response.Result as List<Clanarina>;
        }

        public List<Klijent> UcitajListuKlijenata()
        {
            Request request = new Request();
            request.Operation = Operation.UcitajListuKlijenata;
            Send(request);
            Response response = Receive();
            return response.Result as List<Klijent>;
        }
        public List<Teretana> UcitajListuTeretana()
        {
            Request request = new Request();
            request.Operation = Operation.UcitajListuTeretana;
            Send(request);
            Response response = Receive();
            return (List<Teretana>)response.Result;
        }
        public List<Kategorija> UcitajListuKategorija()
        {
            Request request = new Request();
            request.Operation = Operation.UcitajListuKategorija;
            Send(request);
            Response response = Receive();
            return (List<Kategorija>)response.Result;
        }
        public List<Paket> UcitajListuPaketa()
        {
            Request request = new Request();
            request.Operation = Operation.UcitajListuPaketa;
            Send(request);
            Response response = Receive(); ;
            return (List<Paket>)response.Result;
        }

        public List<Clanarina> UcitajListuClanarina()
        {
            Request request = new Request
            {
                Operation = Operation.UcitajListuClanarina
            };
            Send(request);
            Response response = Receive();
            return (List<Clanarina>)response.Result;
        }

       

        internal void Exit(User user)
        {
            Request req = new Request();
            req.Operation = Operation.Exit;
            req.Argument = user;
            Send(req);
        }

        internal Response KreirajTP(PaketTeretana paketTeretana)
        {
            Request req = new Request();
            req.Operation = Operation.KreirajPT;
            req.Argument = paketTeretana;
            Send(req);
            return (Response)receiver.Receive();
        }

        public List<PaketTeretana> NadjiPT(object argument)
        {
            Request request = new Request();
            request.Operation = Operation.NadjiPT;
            request.Argument= argument;
            Send(request);
            Response response = Receive();
            return response.Result as List<PaketTeretana>;
        }

        internal Response ObrisiPT(PaketTeretana pt)
        {
            Request request = new Request {
                Operation = Operation.ObrisiPT,
                Argument = pt
            };
            Send(request);
            Response response = Receive();
            return response;
        }

        internal Response ObrisiClanarinu(Clanarina c)
        {
            Request request = new Request
            {
                Operation = Operation.ObrisiClanarinu,
                Argument = c
            };
            Send(request);
            Response response = Receive();
            return response;
        }

        internal List<Teretana> PretraziTeretane(string text)
        {
            Request request = new Request
            {
                Operation = Operation.PretraziTeretanu,
                Argument = text
            };
            Send(request);
            Response response = Receive();
            return response.Result as List<Teretana>;
        }

        internal void Logout()
        {



            Request req = new Request
            {
                Operation = Operation.Logout,
            };
            try
            {
                if (sender != null && receiver != null)
                {
                    sender.Send(req);
                    receiver.Close();  // Ako receiver ima metodu Close
                    sender.Close();    // Ako sender ima metodu Close
                }
                if (socket != null)
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    socket = null; // Osigurati da je soket null nakon zatvaranja
                }
                connected = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Logout failed: " + ex.Message);
            }
        }
    }
    }

