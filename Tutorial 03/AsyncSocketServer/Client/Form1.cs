﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Models;

namespace Client
{
    public partial class frmClient : Form
    {
        private readonly Models.Client client;
        public frmClient()
        {
            InitializeComponent();
            client = new Models.Client();
        }

        private async void frmClient_Load(object sender, EventArgs e)
        {
            await client.Connect();
            lblStatus.Text = "Connected";
        }
    }
}
