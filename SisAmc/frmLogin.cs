using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


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
                MessageBox.Show("Por favor preencher Email e Senha", "Alerta");
               
                

            }
            else
            {
                if(vUser == "jefferson@mcmolas.com.br" && vPassword == "123")
                {
                    lblStatusLogin.Text = "Email correto";
                    lblStatusPassword.Text = "Senha correta";

                   

                    new parentPrincipal().Show();

                    




                }
                else
                {
                    MessageBox.Show("Favor verificar dados inseridos", "Alerta");
                    txtEmail.Text = String.Empty;
                    txtPassword.Text = String.Empty;

                }
            }
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            try
            {
                // PASSA A STRING DE CONEXÃO
                MySqlConnection ObjCon = new MySqlConnection(" server=localhost; port=3306; User Id=jefferson; database=mcmolas; password=root");
                // ABRE O BANDO DE DADOS
                ObjCon.Open();
                MessageBox.Show("Conectado");
                // FECHA A CONEXÃO
                ObjCon.Close();
            }
            catch
            {
                MessageBox.Show("Não foi possivel conectar");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
