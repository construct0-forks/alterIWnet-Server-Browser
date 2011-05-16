﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;

namespace aIWServerBrowser
{
    class GameStartingUI : Form
    {
        private Label label1;
        public GameStartingUI()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "alterIWnet is starting!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GameStartingUI
            // 
            this.ClientSize = new System.Drawing.Size(287, 57);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameStartingUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please wait...";
            this.TopMost = true;
            this.ResumeLayout(false);
            
        }

        public new void Show()
        {
            base.Show();
            new Thread(new ThreadStart(waitUntilGameStarted)).Start();
        }

        delegate void closeDlg();
        private void closeSelf()
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new closeDlg(closeSelf));
                }
                catch { }
                return;
            }
            this.Close();
        }
        private void waitUntilGameStarted()
        {
            while (true)
            {
                if (Process.GetProcessesByName("iw4mp.dat").Length != 0)
                {
                    this.closeSelf();
                    break;
                }
                Thread.Sleep(1000);
            }
        }
    }
}