using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common.CommunicationHelper
{
        public class Sender
        {
        private NetworkStream _stream;
        private BinaryFormatter _formatter;
        private Socket _socket;
        public Sender(Socket socket)
        {
            this._socket = socket;
            _formatter = new BinaryFormatter();
            _stream = new NetworkStream(socket);
        }
        public void Close()
        {
            _stream.Close();
        }
        public void Send(object argument)
        {

            _formatter.Serialize(_stream, argument);
        }

        }
    }

