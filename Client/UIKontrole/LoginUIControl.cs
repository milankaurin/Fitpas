using Common.CommunicationHelper;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.UIKontrole
{
    public class LoginUIControl
    {
        FrmLogin loginfrm;
        internal void ShowLogInWindow()
        {
            loginfrm = new FrmLogin();
            loginfrm.btnLogIn.Click += btnLogIn_Click;
            loginfrm.ShowDialog();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                Communication.Instance.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            User usr = new User
            {
                Username = loginfrm.textBox1.Text,
                Password = loginfrm.textBox2.Text
            };

            try
            {
                Response response = Communication.Instance.Login(usr);
                if (response.Result != null)
                {
                    MessageBox.Show("Uspesna prijava");
                    MainUIControl.Instance.PrikaziGlavniProzor();
                }
                else if (response.Exception != null)
                {
                    throw new Exception(response.Exception.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}