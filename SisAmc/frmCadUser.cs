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
    public partial class frmCadUser : Form
    {
        public frmCadUser()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            string vNome, vEmail, vSenha;
            bool vAdm;

            vNome = txtNome.Text;
            vEmail = txtEmail.Text;
            vSenha = txtSenha.Text;

            vAdm = ckcAdm.Checked;



            try
            {
                // PASSA A STRING DE CONEXÃO Git Ok
                MySqlConnection ObjCon = new MySqlConnection(" server=localhost; port=3306; User Id=jefferson; database=mcmolas; password=root");
                // ABRE O BANDO DE DADOS
                ObjCon.Open();
                MessageBox.Show("Conectado");
                
                MySqlCommand ObjCom = new MySqlCommand("insert into mcmolas.usersmc( nomeUsr, emailUsr, passSis, permUser) values(?, ?, ?, ?)", ObjCon);
                ObjCom.Parameters.Add("@nomeUsr", MySqlDbType.VarChar, 45).Value = vNome;
                ObjCom.Parameters.Add("@emailUsr", MySqlDbType.VarChar, 45).Value = vEmail;
                ObjCom.Parameters.Add("@passUsr", MySqlDbType.VarChar, 45).Value = vSenha;
                ObjCom.Parameters.Add("@permUsr", MySqlDbType.Bit, 1).Value = vAdm;

                //COMANDO POR EXECUTAR QUERY
                ObjCom.ExecuteNonQuery();

                // FECHA A CONEXÃO
                ObjCon.Close();
            }
            catch
            {
                MessageBox.Show("Não foi possivel conectar");
            }
        }
    }
}
