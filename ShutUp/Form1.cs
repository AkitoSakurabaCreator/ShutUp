using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ShutUp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
        {
            if (e.Reason == SessionEndReasons.Logoff)
            {
                /*
                ProcessStartInfo process = new ProcessStartInfo("cmd.exe", "shutdown /a");
                Process.Start(process);
                */
            }
            else if(e.Reason == SessionEndReasons.SystemShutdown)
            {
                /*
                ProcessStartInfo process = new ProcessStartInfo("cmd.exe", "shutdown /a");
                Process.Start(process);
                */
            }

            if (MessageBox.Show("シャットダウンを検知しました。","INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SystemEvents.SessionEnding += new SessionEndingEventHandler(SystemEvents_SessionEnding);
        }


    }
}
