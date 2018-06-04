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
using System.Collections.Generic;


namespace SisAmc
{
    public partial class CalcularTF : Form
    {
        //PARA ALCANÇAR O OBJETO FORA DO MÉTODO.
        Mola ObjMola = new Mola();
        List<string> vPropriedadesMola = new List<string>();
        public CalcularTF()
        {
            InitializeComponent();
            //Valores de Inicialização
            cmbSentHelice.Items.Insert(0, "Esquerda");
            cmbSentHelice.Items.Insert(1, "Direita");

            cmbLinhaAuto.Items.Insert(0, "Blindado");
            cmbLinhaAuto.Items.Insert(1, "Esportiva");
            cmbLinhaAuto.Items.Insert(2, "Convencional");
            cmbLinhaAuto.Items.Insert(3, "Personalizada");

        }
        //Instanciando o Objeto Mola
       

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( cmbLinhaAuto.SelectedIndex == 0)
            {
                lblCorPintura.BackColor = Color.Black;
            }
            else if(cmbLinhaAuto.SelectedIndex == 1)
            {
                lblCorPintura.BackColor = Color.Blue;
            }else if(cmbLinhaAuto.SelectedIndex == 2)
            {
                lblCorPintura.BackColor = Color.Black;
            }else if(cmbLinhaAuto.SelectedIndex == 3)
            {
                lblCorPintura.BackColor = Color.Orange;
            }

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
            if (vValidacao == false)
            {
                return;
            }
            /////////////////////////////////////////



            string vTf, vAco, vL0, vd, vDi, vIg, vSentHelice;
            float vDe, vIf, vDm, vCompTotal, vRelEnr, vIndEsb, vConstElast, vLbl, vSa, vLn, vSbl, vSn, vSs1, vSs2,
                vLl1, vLl2, vPbl, vPn, vPp2, vPp1, vTtl, vTn, vTt1, vTt2, vVLo, vVd, vVdi, vVig, vBarraTeste, vBarraEnrolar, VPesoMola, vP1, vP2,
                vS1, vS2, vT1, vT2;
            bool vCkcRetifica;
            bool[] vValidaT;

            vL0 = txtAltLivre.Text;
            vPropriedadesMola.Add(vL0);
            vVLo = converteCampos(vL0);

            vd = txtDiamArame.Text;
            vPropriedadesMola.Add(vd);
            vVd = converteCampos(vd);

            vDi = txtDiamInterno.Text;
            vPropriedadesMola.Add(vDi);
            vVdi = converteCampos(vDi);

            vIg = txtEspTotais.Text;
            vPropriedadesMola.Add(vIg);
            vVig = converteCampos(vIg);

            vCkcRetifica = ckcRetificada.Checked;
            
          





            if (vVLo == 0 || vVd == 0 || vVdi == 0 || vVig == 0)
            {
                MessageBox.Show(Convert.ToString("Valor digitado invalido, por favor revise os valores digitados"));
                return;
            }

            MessageBox.Show("Conversão ok");


            vDe = ObjMola.calcDiamExt(vVdi, vVd);
            txtDiamExterno.Text = Convert.ToString(vDe);
            vPropriedadesMola.Add(txtDiamInterno.Text);

            vIf = ObjMola.calcEspUteis(vVig);
            txtEspUteis.Text = Convert.ToString(vIf);
            vPropriedadesMola.Add(txtEspUteis.Text);

            vDm = ObjMola.calcDiamMed(vVdi, vVd);
            txtDiamMedio.Text = Convert.ToString(vDm);
            vPropriedadesMola.Add(txtDiamMedio.Text);

            //Revisar pois ainda não foi criado em sua totalidade.
            vCompTotal = ObjMola.calcCompFinal(vDm, vVig);
            lblRelCompFinal.Text = Convert.ToString(vCompTotal);

            vRelEnr = ObjMola.calcRelacEnrolamento(vDm, vVd);
            //txtRelEnr.Text = Convert.ToString(vRelEnr);

            if (ObjMola.avaliaRelacEnrolamento(vRelEnr) == false)
            {
                txtRelEnr.ForeColor = Color.Red;
                txtRelEnr.Text = "REPROVADO";
            }
            else
            {
                txtRelEnr.ForeColor = Color.Green;
                txtRelEnr.Text = "APROVADO";
            }

            vIndEsb = ObjMola.calcIndEsbeltez(vVLo, vDm);
            //txtIndEsb.Text = Convert.ToString(vIndEsb);

            if (ObjMola.avaliaIndEsbeltez(vIndEsb) == false)
            {
                txtIndEsb.ForeColor = Color.Red;
                txtIndEsb.Text = "REPROVADO";
            }
            else
            {
                txtIndEsb.ForeColor = Color.Green;
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





            vSs1 = ObjMola.calcSs1(vSn);
            lblSs1.Text = Convert.ToString(vSs1);


            vSs2 = ObjMola.calcSs2(vSn);
            lblSs2.Text = Convert.ToString(vSs2);

            vLl1 = ObjMola.calcLl1(vVLo, vSs1);
            lblLl1.Text = Convert.ToString(vLl1);

            vLl2 = ObjMola.calcLl2(vVLo, vSs2);
            lblLl2.Text = Convert.ToString(vLl2);

            vPbl = ObjMola.calcPbl(vSbl, vConstElast);
            lblPbl.Text = Convert.ToString(vPbl);

            vPn = ObjMola.calcPn(vSn, vConstElast);
            lblPn.Text = Convert.ToString(vPn);

            vPp1 = ObjMola.calcPp1(vSs1, vConstElast);
            lblPp1.Text = Convert.ToString(vPp1);

            vPp2 = ObjMola.calcPp2(vSs2, vConstElast);
            lblPp2.Text = Convert.ToString(vPp2);

            vTtl = ObjMola.calcTbl(vDm, vPbl, vVd);
            lblTbl.Text = Convert.ToString(vTtl);

            vTn = ObjMola.calcTn(vDm, vPn, vVd);
            lblTn.Text = Convert.ToString(vTn);

            vTt1 = ObjMola.calcTt1(vDm, vPp1, vVd);
            lblTt1.Text = Convert.ToString(vTt1);

            vTt2 = ObjMola.calcTt1(vDm, vPp2, vVd);
            lblTt2.Text = Convert.ToString(vTt2);

            vBarraTeste = ObjMola.calcBarraTest(vDm, vCompTotal);
            lblBarraTeste.Text = Convert.ToString(vBarraTeste);

            vBarraEnrolar = ObjMola.calcBarraEnrolar(vCompTotal);
            lblBarraEnrolar.Text = Convert.ToString(vBarraEnrolar);

            VPesoMola = Convert.ToSingle(ObjMola.calcPesoUnid(vVd, vCompTotal));
            lblPesoMola.Text = Convert.ToString(VPesoMola);

            vS1 = ObjMola.calcS1(vSs1);
            lblS1.Text = Convert.ToString(vS1);

            //Corregir calculo
            vS2 = ObjMola.calcS2(vSs2);
            lblS2.Text = Convert.ToString(vS2);

            vP1 = ObjMola.calcP1(vS1, vConstElast);
            lblP1.Text = Convert.ToString(vP1);

            vP2 = ObjMola.calcP2(vS2, vConstElast);
            lblP2.Text = Convert.ToString(vP2);


            vT1 = Convert.ToSingle(ObjMola.calcT1(vDm, vP1, vVd));
            lblT1.Text = Convert.ToString(vT1);

            vT2 = Convert.ToSingle(ObjMola.calcT2(vDm, vP2, vVd));
            lblT2.Text = Convert.ToString(vT2);


            vValidaT = ObjMola.avaliaT(vTtl, vTn, vTt1, vTt2, vT1, vT2);
            if (  vValidaT[0] == true)
            {
                lblStatusTbl.ForeColor = Color.Green;
                lblStatusTbl.Text ="APROVADA";
            }
            else
            {
                lblStatusTbl.ForeColor = Color.Red;
                lblStatusTbl.Text = "REPROVADA";
            }

            if (vValidaT[1] == true)
            {
                lblStatusTn.ForeColor = Color.Green;
                lblStatusTn.Text = "APROVADA";
            }
            else
            {
                lblStatusTn.ForeColor = Color.Red;
                lblStatusTn.Text = "REPROVADA";
            }

            if (vValidaT[2] == true)
            {
                lblStatusTt1.ForeColor = Color.Green;
                lblStatusTt1.Text = "APROVADA";
            }
            else
            {
                lblStatusTt1.ForeColor = Color.Red;
                lblStatusTt1.Text = "REPROVADA";
            }

            if (vValidaT[3] == true)
            {
                lblStatusTt2.ForeColor = Color.Green;
                lblStatusTt2.Text = "APROVADA";
            }
            else
            {
                lblStatusTt2.ForeColor = Color.Red;
                lblStatusTt2.Text = "REPROVADA";
            }

            if (vValidaT[4] == true)
            {
                lblStatusT1.ForeColor = Color.Green;
                lblStatusT1.Text = "APROVADA";
            }
            else
            {
                lblStatusT1.ForeColor = Color.Red;
                lblStatusT1.Text = "REPROVADA";
            }

            if (vValidaT[5] == true)
            {
                lblStatusT2.ForeColor = Color.Green;
                lblStatusT2.Text = "APROVADA";
            }
            else
            {
                lblStatusT2.ForeColor = Color.Red;
                lblStatusT2.Text = "REPROVADA";
            }















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
            //checkedListBox1.Items.Insert(0, "Copenhagen");
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtTf.Text = string.Empty;
            txtAco.Text = string.Empty;
            txtAltLivre.Text = string.Empty;
            txtDiamArame.Text = string.Empty;
            txtDiamInterno.Text = string.Empty;
            txtDiamExterno.Text = string.Empty;
            txtDiamMedio.Text = string.Empty;
            txtEspTotais.Text = string.Empty;
            txtEspUteis.Text = string.Empty;
            ckcRetificada.Checked = false;
            //cmSentHelice
            txtMandril.Text = string.Empty;
            txtObs.Text = string.Empty;
            txtTmax.Text = string.Empty;
            txtModTorcao.Text = string.Empty;
            txtConsElast.Text = string.Empty;
            txtSa.Text = string.Empty;
            txtRelEnr.Text = string.Empty;
            txtIndEsb.Text = string.Empty;
            //cmbLinhaAuto

            lblLl1.Text = string.Empty;
            lblLl2.Text = string.Empty;
            lblLn.Text = string.Empty;
            lblLbl.Text = string.Empty;

            lblPp1.Text = string.Empty;
            lblPp2.Text = string.Empty;
            lblPn.Text = string.Empty;
            lblPbl.Text = string.Empty;

            lblSs1.Text = string.Empty;
            lblSs2.Text = string.Empty;
            lblSn.Text = string.Empty;
            lblSbl.Text = string.Empty;

            lblTt1.Text = string.Empty;
            lblTt2.Text = string.Empty;
            lblTn.Text = string.Empty;
            lblTbl.Text = string.Empty;

            lblStatusTt1.Text = string.Empty;
            lblStatusTt2.Text = string.Empty;
            lblStatusTn.Text = string.Empty;
            lblStatusTbl.Text = string.Empty;

            lblP1.Text = string.Empty;
            lblP2.Text = string.Empty;

            lblS1.Text = string.Empty;
            lblS2.Text = string.Empty;

            lblT1.Text = string.Empty;
            lblT2.Text = string.Empty;


            lblStatusT1.Text = string.Empty;
            lblStatusT2.Text = string.Empty;

            lblBarraEnrolar.Text = string.Empty;
            lblBarraTeste.Text = string.Empty;
            lblRelCompFinal.Text = string.Empty;
            lblCorPintura.Text = string.Empty;
            lblPesoMola.Text = string.Empty;
            lblCorPintura.BackColor = Control.DefaultBackColor;






        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            /* A função desse botão será insertar no banco de dados os valores importantes 
            aos calculos dessa mola. 

            Sendo esses valores os seguintes campos: 

            - TF
            - ALTURA LIVRE
            - DIAMETRO INTERNO
            - ESPIRAS TOTAIS
            - RETIFICADA(TRUE/FALSE
            - SENTIDO HELICE
            - MANDRIL
            - OBSERVAÇÕES
            - LINHA AUTOMOTIVA

             
            verificaCampos();
            
            string[] vArrayMola = new string[5];

            vArrayMola[0] = txtAltLivre.Text;
            vArrayMola[1] = txtDiamArame.Text;

            MessageBox.Show(vArrayMola[0] +" "+ vArrayMola[1]);
           */


            if (ckcRetificada.Checked == false)
            {
                vPropriedadesMola.Add("Sem Retifica");

            }
            else
            {
                vPropriedadesMola.Add("Retificada.");
            }


            MessageBox.Show(vPropriedadesMola[0] + " " + vPropriedadesMola[1]  + " " + vPropriedadesMola[2] + " " + vPropriedadesMola[3] + " " + vPropriedadesMola[4] + " " + vPropriedadesMola[5] + " " + vPropriedadesMola[6] );





        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
           

            
        }

        private void CalcularTF_Load(object sender, EventArgs e)
        {

        }
    }
}
