using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerClientChat
{
    public partial class ChatForm : Form
    {
        private readonly Socket _clientSocket;
        private ArraySegment<byte> buffer;

        public ChatForm(Socket socket)
        {
            InitializeComponent();
            _clientSocket = socket;
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtMsg.Text.Trim()))
            {
                buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(txtMsg.Text));
                await _clientSocket.SendAsync(buffer, SocketFlags.None);
                lsMsgs.Items.Add(txtMsg.Text);
            }
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            buffer = new ArraySegment<byte>(new byte[1024]);
            Task.Run(async () =>
            {
                while (true)
                {
                    if(_clientSocket.Available > 0)
                    {
                        int resCount = await _clientSocket.ReceiveAsync(buffer, SocketFlags.None);
                        byte[] newArr = new byte[resCount];
                        Array.Copy(buffer.Array, newArr, resCount);
                        string value = Encoding.UTF8.GetString(newArr);
                        lsMsgs.Invoke(new Action(() => lsMsgs.Items.Add(value)));
                    }
                }
            });
        }
    }
}
