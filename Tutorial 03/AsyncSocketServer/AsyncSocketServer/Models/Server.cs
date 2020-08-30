﻿using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AsyncSocketServer.Models
{
    public class Server
    {
        private readonly Socket serverSocket;
        public readonly List<ClientPC> Clients;

        public Server()
        {
            serverSocket = new Socket(SharedData.serverAddressFamily, SharedData.socketType, SharedData.protocolType);
            Clients = new List<ClientPC>();
        }

        public void Init()
        {
            serverSocket.Bind(new IPEndPoint(SharedData.serverAddress, SharedData.PORT));
            serverSocket.Listen(10);
        }

        public async Task Accept()
        {
            var client = await serverSocket.AcceptAsync();
            var pcClient = new ClientPC
            {
                ClientSocket = client
            };
            Clients.Add(pcClient);
        }
    }
}
