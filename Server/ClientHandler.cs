using Common;
using Common.CommunicationHelper;
using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler
    {
        private Sender sender;
        private Receiver receiver;
        private Socket socket;
        public User user;

        public ClientHandler(Socket socket)
        {
            this.socket = socket;
            sender = new Sender(socket);
            receiver = new Receiver(socket);
        }

        public void HandleRequest()
        {
            try
            {
                while (true)
                {
                    Request req = (Request)receiver.Receive();
                    Response response = ProcessRequest(req);
                    sender.Send(response);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        private Response ProcessRequest(Request req)
        {
            Response response = new Response();
            try
            {
                switch (req.Operation)
                {
                    //case Operation.Login:
                    //    response.Result = Controller.Instance.Login((User)req.Argument);
                    //break;
                    //case Operation.Login:
                    //    User potentialUser = Controller.Instance.Login((User)req.Argument);
                    //    if (potentialUser != null && !IsUserActive(Session.clientHandlers, potentialUser))
                    //    {
                    //        response.Result = potentialUser;
                    //        user = potentialUser; // Postavljanje korisnika za ovog handler-a
                    //        Session.clientHandlers.Add(this); // Dodavanje u listu aktivnih sesija
                    //    }
                    //    else if (potentialUser != null && IsUserActive(Session.clientHandlers, potentialUser))
                    //    {
                    //        response.Exception = new Exception("This account is currently active!");
                    //    }
                    //    else
                    //    {
                    //        response.Exception = new Exception("Invalid credentials.");
                    //    }
                    //    break;

                    case Operation.Login:
                        User potentialUser = Controller.Instance.Login((User)req.Argument);
                        if (potentialUser != null && !IsUserActive(Session.clientHandlers, potentialUser))
                        {
                            response.Result = potentialUser;
                            user = potentialUser; // Postavljanje korisnika za ovog handler-a
                            Session.clientHandlers.Add(this); // Dodavanje u listu aktivnih sesija
                        }
                        else if (potentialUser != null && IsUserActive(Session.clientHandlers, potentialUser))
                        {
                            response.Exception = new Exception("This account is currently active!");
                        }
                        else
                        {
                            response.Exception = new Exception("Invalid credentials.");
                        }
                        
                        break;

                    case Operation.Logout:
                        Session.clientHandlers.Remove(this);
                        user = null;
                        Stop(); // Osigurati pravilno zatvaranje resursa
                        break;


                    case Operation.KreirajKlijenta:
                        Controller.Instance.KreirajKlijenta((Klijent)req.Argument);
                        break;
                    case Operation.AzurirajKlijenta:
                        Controller.Instance.AzurirajKlijenta((Klijent)req.Argument);
                        break;
                    case Operation.ObrisiKlijenta:
                        Controller.Instance.ObrisiKlijenta((Klijent)req.Argument);
                        break;
                    case Operation.KreirajPaket:
                        response.Result = Controller.Instance.KreirajPaket((Paket)req.Argument);
                        break;
                    case Operation.AzurirajPaket:
                        Controller.Instance.AzurirajPaket((Paket)req.Argument);
                        break;
                    case Operation.ObrisiPaket:
                        try
                        {
                            Controller.Instance.ObrisiPaket((Paket)req.Argument);
                        }
                        catch (Exception ex)
                        {
                            response.Exception = ex; // Ovde postavite izuzetak kako bi klijent mogao da ga obradi
                        }
                        break;


                    case Operation.KreirajTeretanu:
                        response.Result = Controller.Instance.KreirajTeretanu((Teretana)req.Argument);
                        break;
                    case Operation.AzurirajTeretanu:
                        try
                        {
                            Controller.Instance.AzurirajTeretanu((Teretana)req.Argument);
                            response.Result = "Teretana je uspešno ažurirana.";
                        }
                        catch (Exception ex)
                        {
                            response.Exception = ex;
                        }
                        break;
                    case Operation.ObrisiTeretanu:
                        Controller.Instance.ObrisiTeretanu((Teretana)req.Argument);
                        break;
                    case Operation.KreirajKategoriju:
                        Controller.Instance.KreirajKategoriju((Kategorija)req.Argument);
                        break;
                    case Operation.AzurirajKategoriju:
                        Controller.Instance.AzurirajKategoriju((Kategorija)req.Argument);
                        break;
                    case Operation.ObrisiKategoriju:
                        Controller.Instance.ObrisiKategoriju((Kategorija)req.Argument);
                        break;
                    case Operation.KreirajClanarinu:
                        Controller.Instance.KreirajClanarinu((Clanarina)req.Argument);
                        break;
                    case Operation.NadjiKlijenta:
                        response.Result = Controller.Instance.NadjiKlijente((string)req.Argument);
                        break;

                    case Operation.UcitajListuKlijenata:
                        response.Result = Controller.Instance.UcitajListuKlijenata();
                        break;
                    case Operation.UcitajListuPaketa:
                        response.Result = Controller.Instance.UcitajListuPaketa();
                        break;
                    case Operation.UcitajListuTeretana:
                        response.Result = Controller.Instance.UcitajListuTeretana();
                        break;
                    case Operation.UcitajListuKategorija:
                        response.Result = Controller.Instance.UcitajListuKategorija();
                        break;
                    case Operation.UcitajListuClanarina:
                        response.Result = Controller.Instance.UcitajListuClanarina();
                        break;
                    case Operation.PretraziClanarinu:
                        response.Result = Controller.Instance.NadjiClanarinu((string)req.Argument);
                        break;
                    case Operation.AzurirajClanarinu:
                        break;
                    case Operation.Exit:
                        break;
                    case Operation.KreirajPT:
                        Controller.Instance.KreirajPT((PaketTeretana)req.Argument);
                        break;
                    case Operation.NadjiPT:
                        response.Result = Controller.Instance.NadjiPTSO(req.Argument);
                        break;
                    case Operation.ObrisiPT:
                        Controller.Instance.ObrisiPT((PaketTeretana)req.Argument);
                        break;
                    case Operation.ObrisiClanarinu:
                        Controller.Instance.ObrisiClanarinu((Clanarina)req.Argument);
                        break;
                    case Operation.PretraziTeretanu:
                        response.Result = Controller.Instance.PretraziTeretanu((string)req.Argument);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing request: " + ex.Message);
                response.Exception = ex;
            }

            return response;
        }

        private bool IsUserActive(List<ClientHandler> clientHandlers, User user)
        {
            return clientHandlers.Any(handler => handler.user.Username.Equals(user.Username));
        }

        internal void Stop()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            socket = null;
            Session.clientHandlers.Remove(this);
        }
    }

}

