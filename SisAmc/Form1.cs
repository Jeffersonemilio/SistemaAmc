using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisAmc
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vUser;
            string vPassword;

            vUser = txtEmail.Text;
            vPassword = txtPassword.Text;

          

            if ( vUser == string.Empty || vPassword == string.Empty)
            {
                MessageBox.Show("Por favor preencher Email e Senha");
                txtEmail.Text = String.Empty;
                txtPassword.Text = String.Empty;
                

            }
            else
            {
                
            }
        }
    }
}
