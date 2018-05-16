using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisAmc.Resources;


namespace SisAmc
{
    public partial class CalcularTF : Form
    {
        public CalcularTF()
        {
            InitializeComponent();
            //Valores de Inicialização
            cmbSentHelice.Items.Insert(0, "Esquerda");
            cmbSentHelice.Items.Insert(1, "Direita");

        }
        //Instanciando o Objeto Mola
        Mola ObjMola = new Mola();

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {















        }

        private void label77_Click(object sender, EventArgs e)
        {

        }

        private void label75_Click(object sender, EventArgs e)
        {

        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void label72_Click(object sender, EventArgs e)
        {

        }

        private void label74_Click(object sender, EventArgs e)
        {

        }

        private void label71_Click(object sender, EventArgs e)
        {

        }

        private void label70_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ///////// VALIDAÇÃO DOS CAMPOS///////////
            Boolean vValidacao = verificaCampos();
               if(vValidacao == false)
                {
                    return;
                }
            /////////////////////////////////////////
            


            string vTf, vAco, vL0, vd, vDi, vIg, vSentHelice;
            float vDe, vVLo;

            vL0 = txtAltLivre.Text;
            vVLo = converteCampos(vL0);

            if(vVLo == 0)
            {
                MessageBox.Show("É 0");
                return;
            }

            MessageBox.Show("Conversão ok");


            
            vDi = Convert.ToSingle( txtDiamInterno.Text);
            vd = Convert.ToSingle(txtDiamArame.Text);
            
           vDe = ObjMola.calcDiamMed(vDi, vd);
            txtDiamExterno.Text = Convert.ToString(vDe);




            ObjMola.DiametroInterno = Convert.ToSingle(txtDiamInterno.Text);
                lblStatusT1.Text = Convert.ToString(ObjMola.DiametroInterno);

                
                

           

            
        }

        public float converteCampos(string campoParaValidar)
        {
            string vValor;
            vValor = campoParaValidar;
            float vCampo;
            if (float.TryParse(vValor, out vCampo))
            {
                return vCampo;
            }
            else
            {
                MessageBox.Show("Valor digitado invalido, favor revisar");
                return 0;
            }

           
        }
        public Boolean verificaCampos()
        {
            string vTf, vAco, vL0, vd, vDi, vIg, vSentHelice;
            vTf = txtTf.Text;
            vAco = txtAco.Text;
            vL0 = txtAltLivre.Text;
            vd = txtDiamArame.Text;
            vIg = txtEspTotais.Text;
            //Validação pendente
            vSentHelice =Convert.ToString( cmbSentHelice.SelectedText);



            if (vTf == string.Empty || vAco == string.Empty || vL0 == String.Empty || vd == string.Empty || vIg == string.Empty )
            {
                MessageBox.Show("Todos os campos obrigatorios devem ser preenchidos"   );
                return false;
            }
            else
            {
                MessageBox.Show("Tudo ok");
                return true;
            }

            
        }

        private void cmbSentHelice_SelectedIndexChanged(object sender, EventArgs e)
        {
           // checkedListBox1.Items.Insert(0, "Copenhagen");
            
        }
    }
}
