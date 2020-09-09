using AsyncSocketServer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncSocketServer
{
    public partial class Form1 : Form
    {
        private readonly Server server;
        public Form1()
        {
            InitializeComponent();
            server = new Server();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server.Init();
            lblDesc.Text = "Server is Listening...";

            Task.Run(async () =>
            {
                int counter = 0;
                while (true)
                {
                    await server.Accept();
                    lblDesc.Invoke(new Action(() => lblDesc.Text = $"clients: {++counter}"));
                }
            });
        }

        private async void btnOpen_Click(object sender, EventArgs e)
        {
            if(server.Clients.Count > 0)
            {
                var client = server.Clients[0];
                await server.Send("OPEN", client.ClientSocket);
            }
        }
    }
}
