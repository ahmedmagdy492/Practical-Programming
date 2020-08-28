using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib
{
    public static class SharedData
    {
        public const AddressFamily serverAddressFamily = AddressFamily.InterNetwork;
        public const SocketType socketType = SocketType.Stream;
        public const ProtocolType protocolType = ProtocolType.Tcp;
        public static IPAddress serverAddress = new IPAddress(new byte[] {127,0,0,1 });
        public const int PORT = 11111;
    }
}
