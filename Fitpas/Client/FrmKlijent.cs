using Client.UIKontrole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmKlijent : Form
    {
        public FrmKlijent()
        {
            InitializeComponent();
        }

        private void btnDodajKlijenta_Click(object sender, EventArgs e)
        {
           // KlijentUIControl.Instance.DodajKlijentaPanel();
        }

        private void btnIzmeniKlijenta_Click(object sender, EventArgs e)
        {
            //KlijentUIControl.Instance.IzmeniKlijentaPanel();
        }
    }
}
