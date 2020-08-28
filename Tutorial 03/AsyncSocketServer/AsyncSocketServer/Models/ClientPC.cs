using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AsyncSocketServer.Models
{
    public class ClientPC
    {
        public ClientPC()
        {
            ClientId = Guid.NewGuid().ToString();
        }

        public string ClientId { get; set; }
        public Socket ClientSocket { get; set; }
    }
}
