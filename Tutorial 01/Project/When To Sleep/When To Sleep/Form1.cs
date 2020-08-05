using HowToExecuteCommand;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace When_To_Sleep
{
    // 
    public partial class Form1 : Form
    {
        private int counter = 0;
        private int interval = 0;
        private Process[] processes;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            interval = Properties.Settings.Default.interval;
            nmInterval.Value = interval;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int intervalValue = (int)nmInterval.Value;
            Properties.Settings.Default.interval = intervalValue;
            Properties.Settings.Default.Save();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            processes = Process.GetProcesses();

            if (counter < interval)
            {
                counter++;
                lblTime.Text = $"{counter} Mins";
            }
            else
            {
                foreach (var p in processes)
                {
                    if (!p.ProcessName.Contains("IDM"))
                    {
                        var msgBoxResult = MessageBox.Show("Computer will be suspended, Confirm?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (msgBoxResult == DialogResult.OK)
                        {
                            CommandExecutor.ExecuteCommand("RUNDLL32.EXE powrprof.dll,SetSuspendState 0,1,0");
                        }
                        break;
                    }
                }
                counter = 0;
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            notifyIcon1.Icon = Icon;
            notifyIcon1.ShowBalloonTip(2000);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
    }
}
