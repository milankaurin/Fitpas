using Client.UIKontrole;
using Client.UserKontrole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Client
{
    public partial class FrmMain : MetroForm
    {
        public FrmMain()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(frmmain_FormClosing);
        }

       

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            

            
        }

        private void frmmain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da zatvorite aplikaciju?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Slanje zahteva za odjavu
                Communication.Instance.Logout();
            }
            else
            {
                e.Cancel = true; // Ovo sprečava zatvaranje forme
            }
        }

    }
}
