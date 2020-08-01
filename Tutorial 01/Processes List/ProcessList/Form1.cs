using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProcessList
{
    public partial class Form1 : Form
    {
        private readonly Process[] processes;
        public Form1()
        {
            InitializeComponent();
            processes = Process.GetProcesses();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(var item in processes)
            {
                lsProcess.Items.Add(item.ProcessName);
            }
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            if(lsProcess.SelectedItems.Count == 1)
            {
                string processName = (string)lsProcess.SelectedItem;
                var process = processes.FirstOrDefault(p => p.ProcessName == processName);
                process.Kill();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lsProcess.DataSource = Process.GetProcesses();
        }
    }
}
