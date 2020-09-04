using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Client
    {
        private readonly Socket socket;

        public Client()
        {
            socket = new Socket(SharedData.serverAddressFamily, SharedData.socketType, SharedData.protocolType);
        }

        public async Task Connect()
        {
            await socket.ConnectAsync(new IPEndPoint(SharedData.serverAddress, SharedData.PORT));
        }
    }
}
