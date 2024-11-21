using Client.UserKontrole;
using Common;
using Common.CommunicationHelper;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.UIKontrole
{
    internal class PaketiTeretaneUIControl
    {
        private static PaketiTeretaneUIControl instance;
        public static PaketiTeretaneUIControl Instance
        {
            get
            {
                if (instance == null)
                    instance = new PaketiTeretaneUIControl();
                return instance;
            }
        }
        private PaketiTeretaneUIControl() { }

        Teretana teretana;
        FrmPaketiTeretane forma;
        DodajTeretanu dodajTeretanu;
        List<PaketTeretana> paketiteretane;
        PaketTeretana paketTeretana;
        UpravljajPaketima upravljajPaketimacontrola;
        Paket odabranipaket;
        DodajPaket dodajPaket;
        UpravljajTeretanama ut;
        List<Teretana> listaT = Communication.Instance.UcitajListuTeretana();
        List<Paket> listaP = Communication.Instance.UcitajListuPaketa();

        public void osveziPaketeITeretane()
        {
            listaT = Communication.Instance.UcitajListuTeretana();
            listaP = Communication.Instance.UcitajListuPaketa();

        }

        internal void UpravljajPaketimaTeretanama()
        {
            forma = new FrmPaketiTeretane();

            
            forma.panel1.Controls.Add(upravljajPaketimacontrola); forma.dodajTeretanuBtn.Click += DodajTeretanuKontrola;
            forma.upravljajPaketimabtn.Click += UpravljajPaketimaClick;
            forma.btnDodajPaket.Click += DodajPaketClick;
            UpravljajPaketimaPrikaz();
            forma.btnUpravljajTeretanama.Click += UpravljajTeretanaKontrola;
            
            forma.ShowDialog();

        }

        private void UpravljajTeretanaKontrola(object sender, EventArgs e)
        {
           ut = new UpravljajTeretanama();
            ut.txtPretraga.TextChanged += Pretraga;
            ut.dgvTeretane.DataSource = Communication.Instance.UcitajListuTeretana();
            ut.dgvTeretane.Columns["Id"].Visible = false;
            ut.dgvTeretane.SelectionChanged += OdabirTeretane;
            ut.btnAzuriraj.Click += AzurirajTeretanu;
            ut.btnObrisi.Click += ObrisiTeretanu;
            forma.panel1.Controls.Clear();
            forma.panel1.Controls.Add(ut);









        }

        private void ObrisiTeretanu(object sender, EventArgs e)
        {
            if (ut.dgvTeretane.SelectedRows.Count != 0)
            {
                Teretana selectedTeretana = ut.dgvTeretane.SelectedRows[0].DataBoundItem as Teretana;

                DialogResult result = MessageBox.Show(
                    "Da li ste sigurni da želite da obrišete teretanu?",
                    "Potvrda brisanja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    Response res = Communication.Instance.ObrisiTeretanu(selectedTeretana);
                    if (res.Exception == null)
                    {
                        MessageBox.Show("Teretana je obrisana");
                        ut.dgvTeretane.DataSource = Communication.Instance.UcitajListuTeretana();
                    }
                    else
                    {
                        MessageBox.Show("Greška: " + res.Exception.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Morate odabrati teretanu za brisanje.");
            }
        }

       

        private void AzurirajTeretanu(object sender, EventArgs e)
        {
            if (ut.dgvTeretane.SelectedRows.Count != 0)
            {
                Teretana selectedTeretana = ut.dgvTeretane.SelectedRows[0].DataBoundItem as Teretana;
                if (string.IsNullOrWhiteSpace(ut.txtNovNaziv.Text))
                {
                    MessageBox.Show("Unesite novi naziv teretane.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string noviNaziv = ut.txtNovNaziv.Text;
                if (listaT.Any(a => a.ImeTeretane.Equals(noviNaziv, StringComparison.OrdinalIgnoreCase) && a.Id != selectedTeretana.Id))
                {
                    MessageBox.Show("Naziv teretane već postoji. Unesite drugi naziv.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Teretana t = new Teretana
                {
                    Id = selectedTeretana.Id,
                    ImeTeretane = ut.txtNovNaziv.Text
                };

                DialogResult result = MessageBox.Show("Da li ste sigurni da želite da ažurirate teretanu?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Response res = Communication.Instance.AzurirajTeretanu(t);
                    if (res.Exception != null)
                    {
                        MessageBox.Show("Greška prilikom ažuriranja teretane: " + res.Exception.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Upravljanje vezama
                    HashSet<int> trenutnoCekiraniPaketi = new HashSet<int>(ut.checkedListBox1.CheckedItems.Cast<Paket>().Select(p => p.Id));
                    List<PaketTeretana> trenutneVeze = Communication.Instance.NadjiPT(selectedTeretana);
                    var zaBrisanje = trenutneVeze.Where(pt => !trenutnoCekiraniPaketi.Contains(pt.Paket.Id)).ToList();
                    var zaDodavanje = trenutnoCekiraniPaketi.Where(id => !trenutneVeze.Any(pt => pt.Paket.Id == id)).ToList();

                    // Brisanje starih veza
                    foreach (var pt in zaBrisanje)
                    {
                        Communication.Instance.ObrisiPT(pt);
                    }

                    // Dodavanje novih veza
                    foreach (var id in zaDodavanje)
                    {
                        PaketTeretana novaVeza = new PaketTeretana
                        {
                            Paket = new Paket { Id = id },
                            Teretana = t
                        };
                        Communication.Instance.KreirajTP(novaVeza);
                    }

                    MessageBox.Show("Teretana je uspešno ažurirana.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ut.dgvTeretane.DataSource = Communication.Instance.UcitajListuTeretana();
                }
            }
            else
            {
                MessageBox.Show("Nijedna teretana nije selektovana.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OdabirTeretane(object sender, EventArgs e)
        {
            if (ut.dgvTeretane.SelectedRows.Count != 0)
            {
                Teretana selectedTeretana = ut.dgvTeretane.SelectedRows[0].DataBoundItem as Teretana;
                if (selectedTeretana != null)
                {
                    ut.txtNovNaziv.Text = selectedTeretana.ImeTeretane;
                    List<PaketTeretana> trenutneVeze = Communication.Instance.NadjiPT(selectedTeretana);

                    List<Paket> sviPaketi = Communication.Instance.UcitajListuPaketa();
                    List<Paket> odabrani = new List<Paket>();

                    foreach (PaketTeretana pt in trenutneVeze)
                    {
                        odabrani.Add(pt.Paket);
                    }

                    ut.checkedListBox1.DataSource = sviPaketi;
                    ut.checkedListBox1.DisplayMember = "ImePaketa";

                    
                    for (int i = 0; i < ut.checkedListBox1.Items.Count; i++)
                    {
                        Paket paket = ut.checkedListBox1.Items[i] as Paket;
                        if (odabrani.Any(p => p.Id == paket.Id))
                        {
                            ut.checkedListBox1.SetItemChecked(i, true);
                        }
                        else
                        {
                            ut.checkedListBox1.SetItemChecked(i, false);
                        }
                    }
                }
            }
        }

        private void Pretraga(object sender, EventArgs e)
        {
            BindingList<Teretana> teretane = new BindingList<Teretana>(Communication.Instance.PretraziTeretane(ut.txtPretraga.Text));
            ut.dgvTeretane.DataSource = teretane;
        }
        private void DodajPaketClick(object sender, EventArgs e)
        { dodajPaket = new DodajPaket();
            dodajPaket.button1.Click += KreirajPaketButton;

            forma.panel1.Controls.Clear();
            
            List<Teretana> listateretana = new List<Teretana>();
            listateretana = Communication.Instance.UcitajListuTeretana();
            foreach(Teretana t in listateretana)
            {
                dodajPaket.CheckedTeretane.Items.Add(t);
            }
            dodajPaket.CheckedTeretane.DisplayMember = "ImeTeretane";
            forma.panel1.Controls.Add(dodajPaket);         

        }

        private void KreirajPaketButton(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dodajPaket.txtCena.Text) || string.IsNullOrWhiteSpace(dodajPaket.imeTeretaneTxt.Text))
            {
                MessageBox.Show("Sva polja moraju biti popunjena.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(dodajPaket.txtCena.Text, out int cena))
            {
                MessageBox.Show("Cena mora biti broj.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string imePaketa = dodajPaket.imeTeretaneTxt.Text;

            
            List<Paket> listaP = Communication.Instance.UcitajListuPaketa();

           
            bool imePostoji = listaP.Any(p => p.ImePaketa.Equals(imePaketa, StringComparison.OrdinalIgnoreCase));
            if (imePostoji)
            {
                MessageBox.Show("Ime paketa već postoji. Molimo izaberite drugo ime.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Paket paket = new Paket()
            {
                Cena = cena,
                ImePaketa = imePaketa,
                Teretane = new List<Teretana>()
            };

            DialogResult result = MessageBox.Show("Da li ste sigurni da želite da kreirate paket?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    paket.Id = Communication.Instance.KreirajPaket(paket);

                    List<Teretana> listaTeretana = new List<Teretana>();
                    foreach (object itemChecked in dodajPaket.CheckedTeretane.CheckedItems)
                    {
                        Teretana t = itemChecked as Teretana;
                        if (t != null)
                        {
                            listaTeretana.Add(t);
                            PaketTeretana pt1 = new PaketTeretana
                            {
                                IdPaketa = paket.Id,
                                IdTeretane = t.Id,
                                Teretana = t,
                                Paket = paket
                            };
                            Communication.Instance.KreirajTP(pt1);
                        }
                    }

                    MessageBox.Show("Paket i veze su uspešno kreirane.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška prilikom kreiranja paketa: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    MainUIControl.Instance.Osvezi();
                    osveziPaketeITeretane();
                }
            }
        }

        private void UpravljajPaketimaPrikaz()
        {
            upravljajPaketimacontrola = new UpravljajPaketima();
            upravljajPaketimacontrola.comboBox1.DataSource = Communication.Instance.UcitajListuPaketa();
            upravljajPaketimacontrola.comboBox1.DisplayMember = "ImePaketa";
            upravljajPaketimacontrola.comboBox1.SelectedIndex = -1;
            upravljajPaketimacontrola.comboBox1.SelectedValueChanged += ComboBoxOdabir;
            upravljajPaketimacontrola.button1.Click += CuvanjeIzmenaPaketa;
            
            upravljajPaketimacontrola.btnObrisiPaket.Click += ObrisiPaket;
            upravljajPaketimacontrola.btnObrisiPaket.Click += ComboBoxOdabir;
            forma.panel1.Controls.Clear();
            forma.panel1.Controls.Add(upravljajPaketimacontrola);
        }

        private void ObrisiPaket(object sender, EventArgs e)
        {
            if (upravljajPaketimacontrola.comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati paket za brisanje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Paket paket = upravljajPaketimacontrola.comboBox1.SelectedItem as Paket;

            
            DialogResult confirmResult = MessageBox.Show("Da li ste sigurni da želite da obrišete izabrani paket?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    

                    Communication.Instance.ObrisiPaket(paket);

                    MessageBox.Show("Paket je uspešno obrisan.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    upravljajPaketimacontrola.comboBox1.DataSource = Communication.Instance.UcitajListuPaketa();
                    upravljajPaketimacontrola.comboBox1.DisplayMember = "ImePaketa";
                    MainUIControl.Instance.Osvezi();
                    osveziPaketeITeretane();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Nije moguće obrisati paket jer je u upotrebi: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }




        }

        private void UpravljajPaketimaClick(object sender, EventArgs e)
        {
            upravljajPaketimacontrola = new UpravljajPaketima();
            upravljajPaketimacontrola.comboBox1.DataSource = Communication.Instance.UcitajListuPaketa();
            upravljajPaketimacontrola.comboBox1.DisplayMember = "ImePaketa";
                       
            upravljajPaketimacontrola.comboBox1.SelectedValueChanged += ComboBoxOdabir;
            upravljajPaketimacontrola.button1.Click += CuvanjeIzmenaPaketa;
            
            upravljajPaketimacontrola.btnObrisiPaket.Click += ObrisiPaket;
            upravljajPaketimacontrola.btnObrisiPaket.Click += ComboBoxOdabir;

            forma.panel1.Controls.Clear();
            forma.panel1.Controls.Add(upravljajPaketimacontrola);
        }
        private void CuvanjeIzmenaPaketa(object sender, EventArgs e)
            {
                try
                {
                    if (upravljajPaketimacontrola.comboBox1.SelectedIndex == -1)
                    {
                        MessageBox.Show("Morate izabrati paket za ažuriranje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!int.TryParse(upravljajPaketimacontrola.textBox1.Text, out int cena) || cena <= 0)
                    {
                        MessageBox.Show("Unesite validnu cenu paketa (celobrojna vrednost veća od 0).", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string novoImePaketa = upravljajPaketimacontrola.textBox2.Text;
                    List<Paket> listaPaketa = Communication.Instance.UcitajListuPaketa();

                    if (listaPaketa.Any(p => p.ImePaketa.Equals(novoImePaketa, StringComparison.OrdinalIgnoreCase) && p.Id != (upravljajPaketimacontrola.comboBox1.SelectedItem as Paket).Id))
                    {
                        MessageBox.Show("Ime paketa već postoji. Unesite jedinstveno ime paketa.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DialogResult result = MessageBox.Show("Da li ste sigurni da želite da ažurirate paket?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        Paket odabraniPaket = upravljajPaketimacontrola.comboBox1.SelectedItem as Paket;
                        HashSet<Teretana> trenutnoCekiraneTeretane = new HashSet<Teretana>(upravljajPaketimacontrola.checkedListBox1.CheckedItems.Cast<Teretana>());
                        List<PaketTeretana> listaStarihPT = Communication.Instance.NadjiPT(odabraniPaket);
                        HashSet<Teretana> stareTeretane = new HashSet<Teretana>(listaStarihPT.Select(pt => pt.Teretana));

                        foreach (var pt in listaStarihPT.Where(pt => !trenutnoCekiraneTeretane.Contains(pt.Teretana)))
                        {
                            Communication.Instance.ObrisiPT(pt);
                        }

                        foreach (var teretana in trenutnoCekiraneTeretane.Where(t => !stareTeretane.Contains(t)))
                        {
                            Communication.Instance.KreirajTP(new PaketTeretana { Paket = odabraniPaket, Teretana = teretana });
                        }

                        odabraniPaket.ImePaketa = novoImePaketa;
                        odabraniPaket.Cena = cena;
                        Communication.Instance.AzurirajPaket(odabraniPaket);

                        MessageBox.Show("Paket je uspešno ažuriran.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        osveziPaketeITeretane();
                        upravljajPaketimacontrola.comboBox1.DataSource = Communication.Instance.UcitajListuPaketa();
                        upravljajPaketimacontrola.comboBox1.DisplayMember = "ImePaketa";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška prilikom ažuriranja paketa: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        
    
        private void ComboBoxOdabir(object sender, EventArgs e)
        {
            upravljajPaketimacontrola.checkedListBox1.Items.Clear();

            odabranipaket = upravljajPaketimacontrola.comboBox1.SelectedItem as Paket;
            upravljajPaketimacontrola.textBox2.Text = odabranipaket.ImePaketa;
            upravljajPaketimacontrola.textBox1.Text = odabranipaket.Cena.ToString();
            List<Teretana> list = new List<Teretana>();
            List<PaketTeretana> lista1 = new List<PaketTeretana>();
            lista1 = Communication.Instance.NadjiPT(odabranipaket);
            foreach (PaketTeretana pt in lista1)
            {
                list.Add(pt.Teretana);
            }



            Dictionary<int, Teretana> dict = list.ToDictionary(ta => ta.Id);

            foreach (Teretana te in Communication.Instance.UcitajListuTeretana())
            {
                // Provjera da li ID postoji u rečniku
                if (dict.ContainsKey(te.Id))
                {
                    upravljajPaketimacontrola.checkedListBox1.Items.Add(te, true);  // Dodaj kao "checked"
                }
                else
                {
                    upravljajPaketimacontrola.checkedListBox1.Items.Add(te, false); // Dodaj kao "unchecked"
                }
            }
            upravljajPaketimacontrola.checkedListBox1.DisplayMember = "ImeTeretane";

        }
        private void DodajTeretanuKontrola(object sender, EventArgs e)
        {
            dodajTeretanu = new DodajTeretanu();

            List<Paket> dostupniPaketi = Communication.Instance.UcitajListuPaketa();

            
            foreach (Paket paket in dostupniPaketi)
            {
                dodajTeretanu.checkedListBox1.Items.Add(paket, false);  
            }
            dodajTeretanu.checkedListBox1.DisplayMember = "ImePaketa";

            forma.panel1.Controls.Clear();
            forma.panel1.Controls.Add(dodajTeretanu);
              
            dodajTeretanu.button1.Click += DodajTeretanuClick;


        }
        private void DodajTeretanuClick(object sender, EventArgs e)
        {
            // Inicijalizacija nove teretane
            teretana = new Teretana();

            // Provera da li je tekstualno polje za ime teretane prazno
            if (string.IsNullOrWhiteSpace(dodajTeretanu.textBox1.Text))
            {
                MessageBox.Show("Morate uneti ime teretane.");
                return; // Prekida se izvršavanje funkcije ako je polje prazno
            }

            // Postavljanje imena teretane
            teretana.ImeTeretane = dodajTeretanu.textBox1.Text;

            // Lista za čuvanje selektovanih paketa
            List<Paket> selektovaniPaketi = new List<Paket>();

            // Prolazak kroz selektovane pakete u checkedListBox-u
            foreach (var item in dodajTeretanu.checkedListBox1.CheckedItems)
            {
                if (item is Paket paket)
                {
                    // Dodavanje paketa u listu selektovanih paketa
                    selektovaniPaketi.Add(paket);
                }
            }

            // Postavljanje liste selektovanih paketa teretani
            teretana.Paketi = selektovaniPaketi;

            try
            {
                // Kreiranje teretane na serveru i dobijanje ID-ja
                teretana.Id = Communication.Instance.KreirajTeretanu(teretana);

                // Kreiranje veza Paket - Teretana za svaki selektovani paket
                foreach (var paket in selektovaniPaketi)
                {
                    PaketTeretana paketTeretana = new PaketTeretana
                    {
                        Paket = paket,
                        Teretana = teretana
                    };

                    // Kreiranje veze na serveru
                    Response res = Communication.Instance.KreirajTP(paketTeretana);
                    if (res.Exception != null)
                    {
                        MessageBox.Show("Greška prilikom kreiranja veze Paket - Teretana.");
                        return; // Prekida se izvršavanje u slučaju greške
                    }
                }

                // Ako sve prođe uspešno, ispišemo poruku korisniku
                MessageBox.Show("Teretana je uspešno kreirana i veze sa paketima su uspešno dodate.");
            }
            catch (Exception ex)
            {
                // Uhvatimo bilo kakav exception koji može nastati i prikažemo korisniku poruku
                MessageBox.Show($"Došlo je do greške: {ex.Message}");
            }
        }





    }
}
