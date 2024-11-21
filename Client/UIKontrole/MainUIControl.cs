using Client.UserKontrole;
using Common.CommunicationHelper;
using Common;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Windows.Forms;

namespace Client.UIKontrole
{
    public class MainUIControl
    {
        public FrmMain frmmain;

        private static MainUIControl instance;
        public static MainUIControl Instance
        {
            get
            {
                if (instance == null)
                    instance = new MainUIControl();
                return instance;
            }
        }
        private MainUIControl() { }

        Klijent klijent;
        BindingList<Klijent> klijenti = new BindingList<Klijent>(Communication.Instance.UcitajListuKlijenata());
        BindingList<Paket> paketi = new BindingList<Paket>(Communication.Instance.UcitajListuPaketa());
        BindingList<Kategorija> kategorije = new BindingList<Kategorija>(Communication.Instance.UcitajListuKategorija());


        public void Osvezi()
        {
            klijenti= new BindingList<Klijent>(Communication.Instance.UcitajListuKlijenata());
            paketi = new BindingList<Paket>(Communication.Instance.UcitajListuPaketa());
            kategorije = new BindingList<Kategorija>(Communication.Instance.UcitajListuKategorija());
            frmmain.dgvKlijenti.DataSource = klijenti;
            frmmain.dgvKlijenti.Columns["DatumRodjenja"].DefaultCellStyle.Format = "d";
            frmmain.comboPaket.DataSource = paketi;
            frmmain.comboKategorije.DataSource = kategorije;



        }


        internal void PrikaziGlavniProzor()
        {
            frmmain = new FrmMain();
            frmmain.dgvKlijenti.AllowUserToAddRows= false;
            frmmain.klijentiBtn.Click += KlijentiBtnClick;
            frmmain.btnPaketiTeretane.Click +=
                PaketiTeretaneClick;
            frmmain.dgvKlijenti.DataSource = klijenti;
            frmmain.dgvKlijenti.Columns["DatumRodjenja"].DefaultCellStyle.Format = "d";
            frmmain.comboPaket.DataSource = paketi;
            frmmain.comboPaket.DisplayMember = "Prikaz";
            frmmain.comboKategorije.DataSource = kategorije;
            frmmain.comboKategorije.DisplayMember = "Prikaz";
            frmmain.dgvKlijenti.Columns["Id"].Visible = false;
            frmmain.dateCurrent.Text= DateTime.Now.ToShortDateString();
            frmmain.date30.Text = DateTime.Now.AddDays(30).ToShortDateString();
            frmmain.txtPretragaKlijenta.TextChanged += Pretraga;
            frmmain.btnKreiraj.Click += KreirajClanarinuKlik;
            frmmain.btnKategorije.Click += BtnKategorije_Click;
            
            
            frmmain.Load += (s, e) => {
                frmmain.BeginInvoke((MethodInvoker)delegate {
                    frmmain.dgvKlijenti.ClearSelection();
                });
            };
           frmmain.btnLogOut.Click += Odjava;
            
            frmmain.ShowDialog();
           
          
        }

        private void BtnKategorije_Click(object sender, EventArgs e)
        {
            Form form = new Form
            {
                Text = "Pregled kategorija",
                Size = new Size(600, 400), 
                StartPosition = FormStartPosition.CenterScreen,  
                FormBorderStyle = FormBorderStyle.FixedDialog, 
                MaximizeBox = false, 
                MinimizeBox = false 
            };

            PregledKategorija pk = new PregledKategorija
            {
                Dock = DockStyle.Fill 
            };
            pk.dataGridView1.DataSource = Communication.Instance.UcitajListuKategorija();

            form.Controls.Add(pk);

            
            form.ShowDialog();
        }

        private void Odjava(object sender, EventArgs e)
        {

          
            if (frmmain != null && !frmmain.IsDisposed)
            {
                frmmain.Close();
            }
        }

        private void Pretraga(object sender, EventArgs e)
        {
            klijenti = new BindingList<Klijent>(Communication.Instance.PretraziKlijente(frmmain.txtPretragaKlijenta.Text));
            frmmain.dgvKlijenti.DataSource = klijenti;
        }
    

        private void KreirajClanarinuKlik(object sender, EventArgs e)
        {
            
            
            Clanarina clanarina = new Clanarina();
            
            bool isValid = true;

            if (frmmain.dgvKlijenti.SelectedRows.Count == 1)
            {
                clanarina.Klijent = frmmain.dgvKlijenti.SelectedRows[0].DataBoundItem as Klijent;
                if (clanarina.Klijent == null)
                {
                    MessageBox.Show("Odabrani red ne sadrži validnog klijenta.");
                    isValid = false;
                }
                List<Clanarina> clanarine = new List<Clanarina>();
                clanarine = Communication.Instance.PretraziClanarine((frmmain.dgvKlijenti.SelectedRows[0].DataBoundItem as Klijent).Id.ToString());
                foreach (Clanarina cl in clanarine)
                {
                    if (cl.DatumDo > DateTime.Now)
                    {
                        MessageBox.Show("U ovom trenutku izabrani klijent već ima aktivnu članarinu");
                        isValid = false;
                    }
                }



            }
            else
            {
                MessageBox.Show("Morate odabrati tačno jednog klijenta.");
                isValid = false;
            }

            if (frmmain.comboPaket.SelectedItem != null)
            {
                clanarina.Paket = frmmain.comboPaket.SelectedItem as Paket;
                if (clanarina.Paket != null)
                {
                    clanarina.Cena = clanarina.Paket.Cena;
                }
                else
                {
                    MessageBox.Show("Odabrani paket nije validan.");
                    isValid = false;
                }
            }
            else
            {
                MessageBox.Show("Morate odabrati paket.");
                isValid = false;
            }

            if (frmmain.comboKategorije.SelectedItem != null)
            {
                clanarina.Kategorija = frmmain.comboKategorije.SelectedItem as Kategorija;
                if (clanarina.Kategorija == null)
                {
                    MessageBox.Show("Odabrana kategorija nije validna.");
                    isValid = false;
                }
            }
            else
            {
                MessageBox.Show("Morate odabrati kategoriju.");
                isValid = false;
            }

            

            if (isValid)
            {
                clanarina.DatumOd = DateTime.Now;
                clanarina.DatumDo = DateTime.Now.AddDays(30);
                clanarina.Cena =(clanarina.Paket.Cena * (100 - clanarina.Kategorija.Popust)) / 100;

                string poruka = $"Klijent: {clanarina.Klijent.Ime} {clanarina.Klijent.Prezime}{Environment.NewLine}" +
                       $"Paket: {clanarina.Paket.ImePaketa}{Environment.NewLine}" +
                       $"Kategorija: {clanarina.Kategorija.Naziv} ({clanarina.Kategorija.Popust}% popust){Environment.NewLine}" +
                       $"Cena: {clanarina.Cena} RSD{Environment.NewLine}" +
                       $"Datum od: {clanarina.DatumOd.ToShortDateString()}{Environment.NewLine}" +
                       $"Datum do: {clanarina.DatumDo.ToShortDateString()}{Environment.NewLine}" +
                       "Da li ste sigurni da želite nastaviti?";

                DialogResult result = MessageBox.Show(poruka, "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                

                if (result == DialogResult.Yes)
                {
                    Response res = Communication.Instance.KreirajClanarinu(clanarina);
                    if (res.Exception == null)
                    {
                        MessageBox.Show("Sistem je uspesno kreirao clanarinu!");
                    }
                }
                else if (result == DialogResult.No)
                {
                    MessageBox.Show("Odustali ste.");
                }

               
            }
            else { clanarina = new Clanarina(); }

        }

        private void PaketiTeretaneClick(object sender, EventArgs e)
        {
         
            PaketiTeretaneUIControl.Instance.UpravljajPaketimaTeretanama();
        }

        private void KlijentiBtnClick(object sender, EventArgs e)
        {
            KlijentUIControl.Instance.UpravljajKlijentima();
        }
    
    
    
    }
}