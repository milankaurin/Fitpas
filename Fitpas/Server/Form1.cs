using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        private Server server;
        private Timer updateTimer;
        public Form1()
        {
            InitializeComponent();
            updateTimer = new Timer();
            updateTimer.Interval = 1000; // Na primer, osvežavanje svake sekunde
            updateTimer.Tick += (sender, args) => UpdateUserList();
            updateTimer.Start();



        }

        private void UpdateUserList()
        {
            BindingList<User> users = new BindingList<User>();

            foreach (ClientHandler ch in Session.clientHandlers)
            {
                User user = ch.user;
                users.Add(user);

            }
            

            dgvUsers.DataSource = users;
            dgvUsers.Columns["Id"].Visible = false;
        }

        //private void btnStart_Click(object sender, EventArgs e)
        //{
        //    server = new Server();
        //    btnStart.Enabled = false;
        //    btnStop.Enabled = true;
        //    textBox1.Text = "Server je pokrenut!";
        //    server.Start();
        //}

        //private void btnStop_Click(object sender, EventArgs e)
        //{
        //    btnStart.Enabled = true;
        //    btnStop.Enabled = false;
        //    textBox1.Text = "Server je zaustavljen!";
        //    server.Stop();
        //}

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            server = new Server();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            textBox1.Text = "Server je pokrenut!";
            server.Start();
            
        }

        private void btnStop_Click_1(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            textBox1.Text = "Server je zaustavljen!";
            server.Stop();
        }

        

    }
}