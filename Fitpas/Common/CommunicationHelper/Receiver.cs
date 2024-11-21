using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common.CommunicationHelper
{
    public class Receiver
    {

        private Socket _socket;
        private BinaryFormatter _formatter;
        private NetworkStream _stream;

        public Receiver(Socket sokcet)
        {
            _socket = sokcet;
            _formatter = new BinaryFormatter();
            _stream = new NetworkStream(sokcet);
        }

        public void Close()
        {
            _stream.Close();
        }

        public object Receive()
        {
            return _formatter.Deserialize(_stream);
        }

    }
}
