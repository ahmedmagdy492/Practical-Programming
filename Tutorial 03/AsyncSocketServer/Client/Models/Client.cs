using Newtonsoft.Json;
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

        public Socket Socket { get { return socket; } }

        public Client()
        {
            socket = new Socket(SharedData.serverAddressFamily, SharedData.socketType, SharedData.protocolType);
        }

        public async Task Connect()
        {
            await socket.ConnectAsync(new IPEndPoint(SharedData.serverAddress, SharedData.PORT));
        }

        public async Task<Message> RecMsg()
        {
            var buffer = new byte[1024];
            var arrayseg = new ArraySegment<byte>(buffer);
            await socket.ReceiveAsync(arrayseg, SocketFlags.None);
            var msgStr = Encoding.UTF8.GetString(arrayseg.Array);
            var msg = JsonConvert.DeserializeObject<Message>(msgStr);
            return msg;
        }
    }
}
