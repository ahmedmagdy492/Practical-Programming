using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerClientChat
{
    public partial class Form1 : Form
    {
        private readonly Socket socket;
        private Socket clientSocket;
        private const int PORT = 9999;
        public Form1()
        {
            InitializeComponent();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            socket.Bind(new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), PORT));
            socket.Listen(5);
            btnStart.Enabled = false;
            btnStart.Text = "Listining on port " + PORT + ".....";

            clientSocket = await socket.AcceptAsync();

            ChatForm chat = new ChatForm(clientSocket);
            chat.Text = socket.LocalEndPoint.ToString();
            chat.ShowDialog();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            await socket.ConnectAsync(new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1}), PORT));

            ChatForm chat = new ChatForm(socket);
            chat.Text = socket.LocalEndPoint.ToString();
            chat.ShowDialog();
        }
    }
}
