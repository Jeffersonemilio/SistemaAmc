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
            float vDe, vIf, vDm, vCompTotal, vRelEnr, vIndEsb, vConstElast, vLbl, vSa, vLn, vSbl, vSn,
                vVLo, vVd, vVdi, vVig;
            bool vCkcRetifica;

            vL0 = txtAltLivre.Text;
            vVLo = converteCampos(vL0);

            vd = txtDiamArame.Text;
            vVd = converteCampos(vd);

            vDi = txtDiamInterno.Text;
            vVdi = converteCampos(vDi);

            vIg = txtEspTotais.Text;
            vVig = converteCampos(vIg);

            vCkcRetifica = ckcRetificada.Checked;





            if(vVLo == 0 || vVd == 0 || vVdi == 0 || vVig == 0)
            {
                MessageBox.Show(Convert.ToString("Valor digitado invalido, por favor revise os valores digitados"));
                return;
            }

            MessageBox.Show("Conversão ok");

       
            vDe = ObjMola.calcDiamExt(vVdi, vVd);
            txtDiamExterno.Text = Convert.ToString(vDe);

            vIf = ObjMola.calcEspUteis(vVig);
            txtEspUteis.Text = Convert.ToString(vIf);

            vDm = ObjMola.calcDiamMed(vVdi, vVd);
            txtDiamMedio.Text = Convert.ToString(vDm);

            //Revisar pois ainda não foi criado em sua totalidade.
            vCompTotal = ObjMola.calcCompFinal(vDm, vVig);
            lblRelCompFinal.Text = Convert.ToString(vCompTotal);

            vRelEnr = ObjMola.calcRelacEnrolamento(vDm, vVd);
            //txtRelEnr.Text = Convert.ToString(vRelEnr);

            if (ObjMola.avaliaRelacEnrolamento(vRelEnr) == false)
            {
                txtRelEnr.Text = "REPROVADO";
            }
            else
            {
                txtRelEnr.Text = "APROVADO";
            }

            vIndEsb = ObjMola.calcIndEsbeltez(vVLo, vDm);
            //txtIndEsb.Text = Convert.ToString(vIndEsb);

            if (ObjMola.avaliaIndEsbeltez(vIndEsb) == false)
            {
                txtIndEsb.Text = "REPROVADO";
            }
            else
            {
                txtIndEsb.Text = "APROVADO";
            }

             
            vConstElast = Convert.ToSingle(ObjMola.calcConstElast(100, vVd, vDm, vIf));
            txtConsElast.Text = Convert.ToString(vConstElast);

            vSa = Convert.ToSingle(ObjMola.calcSa(vDm, vVd, vIf));
            txtSa.Text = Convert.ToString(vSa);

            vLbl = ObjMola.calcLbl(vVig, vVd, vCkcRetifica);
            lblLbl.Text = Convert.ToString(vLbl);

            vLn = ObjMola.calcLn(vSa, vLbl);
            lblLn.Text = Convert.ToString(vLn);

            vSbl = ObjMola.calcSbl(vLbl, vVLo);
            lblSbl.Text = Convert.ToString(vSbl);

            vSn = ObjMola.calcSn(vSbl, vSa);
            lblSn.Text = Convert.ToString(vSn);


        
            
        




            

                
                

           

            
        }


        
        //Esse Metodo verifica se todos os campo foram preenchidos ou se algum campo obrigadorio
        //foi ignorado pelo usuario
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

        //Esse Metodo realiza a conversão e verificação dos valores digitados pelo usuario, sendo possivel
        // realiza a conversão para float, n]ao sendo possivel indica que algo está errado.
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
                // MessageBox.Show("Valor digitado invalido, favor revisar");
                return 0;
            }


        }

        private void cmbSentHelice_SelectedIndexChanged(object sender, EventArgs e)
        {
           // checkedListBox1.Items.Insert(0, "Copenhagen");
            
        }
    }
}
