using Client.UserKontrole;
using Common;
using Common.CommunicationHelper;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.UIKontrole
{
    public class KlijentUIControl
    {
        private static KlijentUIControl instance;
        public static KlijentUIControl Instance
        {
            get
            {
                if (instance == null)
                    instance = new KlijentUIControl();
                return instance;
            }
        }
        private KlijentUIControl() {}


        Klijent klijent;
        DodajKlijenta dodajKlijenta;
        IzmeniKlijenta izmeniKlijenta;
        BindingList<Klijent> klijenti;
        FrmKlijent forma;
        ClanarineKorisnika cs;
        public void UpravljajKlijentima()
        {
            forma = new FrmKlijent();



            BindingList<Klijent> klijenti = new BindingList<Klijent>(Communication.Instance.UcitajListuKlijenata());

            forma.dgvKlijenti.DataSource = klijenti;
            forma.dgvKlijenti.Columns["DatumRodjenja"].HeaderText = "Datum rodjenja";
            forma.dgvKlijenti.Columns["DatumRodjenja"].DefaultCellStyle.Format = "d";
            forma.dgvKlijenti.Columns["Id"].Visible = false;



            forma.btnDodajKlijenta.Click += DodajKlijentaPanel;
            forma.btnPregledKlijenta.Click += IzmeniKlijentaPanel;
            forma.sviKlijentiBtn.Click += PregledPanel;
            forma.textBox1.TextChanged += Pretraga;
            forma.ShowDialog();
            
        }

        private void PregledPanel(object sender, EventArgs e)
        {
            klijenti = new BindingList<Klijent>(Communication.Instance.UcitajListuKlijenata());
            forma.panelKlijenti.Controls.Clear();
            forma.dgvKlijenti.DataSource = klijenti;
            forma.dgvKlijenti.Columns["DatumRodjenja"].HeaderText = "Datum rodjenja";
            forma.dgvKlijenti.Columns["DatumRodjenja"].DefaultCellStyle.Format = "d";
            forma.dgvKlijenti.Columns["Id"].Visible = false;
            forma.panelKlijenti.Controls.Add(forma.dgvKlijenti);
          
        }

        private void BtnBrisiClanarinu_Click(object sender, EventArgs e)
        {
            try
            {
                if (izmeniKlijenta.dgvClanarine.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Da li ste sigurni da želite da obrišete odabrane članarine?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in izmeniKlijenta.dgvClanarine.SelectedRows)
                        {
                            if (row.DataBoundItem is Clanarina clanarina)
                            {
                                Response res = Communication.Instance.ObrisiClanarinu(clanarina);
                                if (res.Exception != null)
                                {
                                    throw res.Exception;
                                }
                            }
                        }
                        MessageBox.Show("Brisanje je uspešno.");

                        forma.panelKlijenti.Controls.Clear();
                        BindingList<Klijent> klijenti = new BindingList<Klijent>(Communication.Instance.UcitajListuKlijenata());
                        forma.dgvKlijenti.DataSource = klijenti;
                        forma.panelKlijenti.Controls.Add(forma.dgvKlijenti);
                        MainUIControl.Instance.Osvezi();
                        forma.textBox1.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Brisanje je otkazano.");
                    }
                }
                else
                {
                    MessageBox.Show("Morate odabrati makar jednu članarinu za brisanje");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom brisanja članarine: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Pretraga(object sender, EventArgs e)
        {
           klijenti = new BindingList<Klijent>(Communication.Instance.PretraziKlijente(forma.textBox1.Text));
            forma.dgvKlijenti.DataSource = klijenti;
        }

        private void ObrisiKlijenta(object sender, EventArgs e)
        {
            string message = "Da li ste sigurni da želite da obrišete odabranog klijenta?";
            string title = "Potvrda brisanja";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result = MessageBox.Show(message, title, buttons, icon);

            if (result == DialogResult.Yes)
            {
                Klijent selectedKlijent = forma.dgvKlijenti.SelectedRows[0].DataBoundItem as Klijent;
                Response res = Communication.Instance.ObrisiKlijenta(selectedKlijent);

                if (res.Exception == null)
                {
                    MessageBox.Show("Klijent je obrisan", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindingList<Klijent> klijenti = new BindingList<Klijent>(Communication.Instance.UcitajListuKlijenata());
                    forma.dgvKlijenti.DataSource = klijenti;
                    forma.panelKlijenti.Controls.Clear(); 
                    forma.textBox1.Visible = true;

                    forma.dgvKlijenti.Columns["DatumRodjenja"].HeaderText = "Datum rodjenja";
                    forma.dgvKlijenti.Columns["DatumRodjenja"].DefaultCellStyle.Format = "d";
                    forma.panelKlijenti.Controls.Add(forma.dgvKlijenti);
                    MainUIControl.Instance.Osvezi();
                }
                else
                {
                    MessageBox.Show("Došlo je do greške prilikom brisanja klijenta: " + res.Exception.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public void DodajKlijentaPanel(object sender, EventArgs e)
        {
            dodajKlijenta = new DodajKlijenta();
            forma.panelKlijenti.Controls.Clear();
            forma.panelKlijenti.Controls.Add(dodajKlijenta);
            dodajKlijenta.btnDodaj.Click += DodajKlijenta;
            forma.textBox1.Visible = false;
            
        }

        public void IzmeniKlijentaPanel(object sender, EventArgs e)
        {
            if (forma.dgvKlijenti.SelectedRows.Count == 1)
            {

                Klijent odabrani = forma.dgvKlijenti.SelectedRows[0].DataBoundItem as Klijent;
                izmeniKlijenta = new IzmeniKlijenta();
                forma.panelKlijenti.Controls.Clear();
                forma.textBox1.Visible = false;
                forma.panelKlijenti.Controls.Add(izmeniKlijenta);
                izmeniKlijenta.izmeniKlijentabtn.Click += IzmeniKlijentaKlik;
                izmeniKlijenta.id.Text = odabrani.Id.ToString();
                izmeniKlijenta.ime.Text = odabrani.Ime;
                izmeniKlijenta.prezime.Text = odabrani.Prezime;
                izmeniKlijenta.datrodjenja.Value = odabrani.DatumRodjenja;
                var clanarine = new BindingList<Clanarina>(Communication.Instance.PretraziClanarine(odabrani.Id.ToString()));
                izmeniKlijenta.dgvClanarine.DataSource = clanarine;
                izmeniKlijenta.dgvClanarine.Columns["datumOd"].DefaultCellStyle.Format = "d";
                izmeniKlijenta.dgvClanarine.Columns["datumDo"].DefaultCellStyle.Format = "d";
                izmeniKlijenta.dgvClanarine.Columns["idPaketa"].Visible = false;
                izmeniKlijenta.dgvClanarine.Columns["idKlijenta"].Visible = false;
                izmeniKlijenta.dgvClanarine.Columns["idKategorije"].Visible = false;
                izmeniKlijenta.btnObrisiKlijenta.Click += ObrisiKlijenta;
                izmeniKlijenta.btnBrisiClanarine.Click += BtnBrisiClanarinu_Click;


                izmeniKlijenta.dgvClanarine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                izmeniKlijenta.dgvClanarine.ClearSelection();

            }
            else { MessageBox.Show("morate odabrati tacno jednog klijenta"); }

        }

        private void IzmeniKlijentaKlik(object sender, EventArgs e)
        {
            var textBoxes = new List<TextBox>
    {
        izmeniKlijenta.ime,
        izmeniKlijenta.prezime
    };

            bool svaPoljaPopunjena = true;

            foreach (var textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.BackColor = Color.Red;
                    svaPoljaPopunjena = false;
                }
                else
                {
                    textBox.BackColor = SystemColors.Window;
                }
            }

            if (!svaPoljaPopunjena)
            {
                MessageBox.Show("Nisu popunjena sva polja.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmResult = MessageBox.Show("Da li ste sigurni da želite da sačuvate izmene?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    Klijent kl = new Klijent
                    {
                        Id = int.Parse(izmeniKlijenta.id.Text), 
                        Ime = izmeniKlijenta.ime.Text,
                        Prezime = izmeniKlijenta.prezime.Text,
                        DatumRodjenja = izmeniKlijenta.datrodjenja.Value
                    };

                    Response res = Communication.Instance.AzurirajKlijenta(kl);

                    if (res.Exception == null)
                    {
                        MessageBox.Show("Sistem je uspešno izmenio korisnika.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        forma.panelKlijenti.Controls.Clear();
                        BindingList<Klijent> klijenti = new BindingList<Klijent>(Communication.Instance.UcitajListuKlijenata());
                        forma.dgvKlijenti.DataSource = klijenti;
                        forma.panelKlijenti.Controls.Add(forma.dgvKlijenti);
                        forma.textBox1.Visible = true;
                        MainUIControl.Instance.Osvezi();
                    }
                    else
                    {
                        MessageBox.Show("Došlo je do greške pri izmeni korisnika: " + res.Exception.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Došlo je do greške pri obradi podataka: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        public void DodajKlijenta(object sender, EventArgs e)
        {
            var textBoxes = new List<TextBox>
    {
            dodajKlijenta.ime,
            dodajKlijenta.prezime
    };

            bool svaPoljaPopunjena = true;

            foreach (var textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.BackColor = Color.Red;
                    svaPoljaPopunjena = false;
                }
                else
                {
                    textBox.BackColor = SystemColors.Window;
                }
            }

            if (!svaPoljaPopunjena)
            {
                MessageBox.Show("Nisu popunjena sva polja.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            DialogResult result = MessageBox.Show("Da li ste sigurni da želite da dodate novog klijenta?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Klijent kl = new Klijent
                    {
                        Ime = dodajKlijenta.ime.Text,
                        Prezime = dodajKlijenta.prezime.Text,
                        DatumRodjenja = dodajKlijenta.datrodjenja.Value
                    };

                    Response res = Communication.Instance.KreirajKlijenta(kl);

                    if (res.Exception == null)
                    {
                        MessageBox.Show("Sistem je uspešno kreirao klijenta.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        forma.panelKlijenti.Controls.Clear();
                        BindingList<Klijent> klijenti = new BindingList<Klijent>(Communication.Instance.UcitajListuKlijenata());
                        forma.dgvKlijenti.DataSource = klijenti;
                        forma.panelKlijenti.Controls.Add(forma.dgvKlijenti);
                        MainUIControl.Instance.Osvezi();
                        forma.textBox1.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("greska " + res.Exception.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




    }
}
