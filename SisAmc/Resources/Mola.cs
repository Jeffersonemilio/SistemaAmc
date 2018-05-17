using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAmc.Resources
{
    public class Mola
    {
        private int CodTF;

        private string NomeTF  ;

        private string DataCreacao;

        private string Localizacao;

        public float DiametroInterno;

        private float DiametroArame;

        private float AlturaLivre { get; set; }
       

        private float EspirasTotais;

        private char LinhaAutomotiva;

        private char Observacoes;

        private int Mandril;

        private int Tmax;

        private bool Retifica;

        private bool SentidoEnrola;

        private Mola mola;

        public void selLinhaAuto()
        {
            
        }

        public float calcDiamExt(float DiamentroInterno, float DiamentroArame)
        {
            float vDi, vd;
            vDi = DiamentroInterno;
            vd = DiamentroArame;
            float vDe = vDi + vd * 2;

            return vDe;
        }

        public float calcEspUteis(float EspirasTotais)
        {
            float vIg, vIf;
            vIg = EspirasTotais;
            vIf = vIg - Convert.ToSingle( 1.75 );

            return vIf;
        }

        public float calcDiamMed(float DiametroInterno, float DiametroArame)
        {
            float vDi, vd, vDm;
            vDi = DiametroInterno;
            vd = DiametroArame;
            vDm = vDi + vd;

            return vDm;
        }

        public float calcCompFinal(float DiamentroMedio, float EspirasTotais)
        {
            float vDm, vIg, CompFinal;
            vDm = DiamentroMedio;
            vIg = EspirasTotais;

            CompFinal = vDm * vIg * Convert.ToSingle(Math.PI);

            return CompFinal;
        }

        public float calcRelacEnrolamento(float DiamentroMedio, float DiametroArame)
        {
            float vDm, vd, vW;
            vDm = DiamentroMedio;
            vd = DiametroArame;
            vW = vDm / vd;
            

            return vW;
        }

        public bool avaliaRelacEnrolamento(float vW)
        {
            if (vW < 4 || vW >20)
            {
                return false;
            }
            else
            {
                return true;
            }

            
        }

        public float calcIndEsbeltez(float AlturaLivre, float calcDiamMed)
        {
            float vL0, vDm, vY;
            vL0 = AlturaLivre;
            vDm = calcDiamMed;
            vY = vL0 / vDm;

            return vY;
        }

        public bool avaliaIndEsbeltez(float vY)
        {
            if (vY > 5)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public double calcConstElast(float Tmax, float DiamentroArame, float calcDiamMed, float calcEspUteis)
        {
            double vTmax, vd, vDm, vIf, vConstElast;
            vTmax = Tmax;
            vd = DiamentroArame;
            vDm = calcDiamMed;
            vIf = calcEspUteis;

            //Conta esta correta!!!
            double vC = (8002 * Math.Pow(vd, 4)) / (8 * Math.Pow(vDm, 3) * vIf);
            Convert.ToSingle(vC);
            vConstElast = vC;
            return vConstElast  ;
            //Retorna um Double
        }

        public double calcSa(float calcDiamMed, float DiametroArame, float calcEspUteis)
        {
            double vDm, vd, vIf, vSa;
            vDm = calcDiamMed;
            vd = DiametroArame;
            vIf = calcEspUteis;
            
            //Conta correta, Mais tenho que arredondar as casas decimais.
            vSa = (0.0015 * (Math.Pow(vDm, 2)/ vd) +0.1 * vd) * vIf;
            
            //Retorna um Double
            return vSa;
        }

        public float calcLbl(float EspirasTotais, float DiamentroArame, bool Retifica)
        {
            float vIg, vd, vLbl;
            bool vRetifica ;

            vIg = EspirasTotais;
            vd = DiamentroArame;
            vRetifica = Retifica;

            if (vRetifica == true)
            {
                vLbl = (vIg -  Convert.ToSingle( 0.5 )) * vd;
            }
            else
            {
                vLbl = (vIg + 1) * vd;
            }


            return vLbl;
        }

        public float calcLn(float calcSa, float calcLbl)
        {
            float vSa, vLbl, vLn;
            vSa = calcSa;
            vLbl = calcLbl;
            vLn = vSa + vLbl;


            return vLn;
        }

        public float calcSbl(float calcLbl, float AlturaLivre)
        {
            float vLbl, vL0, vSbl;
            vLbl = calcLbl;
            vL0 = AlturaLivre;

            return vSbl = vL0 - vLbl;

            
        }

        public float calcSn(float calcSbl, float calcSa)
        {
            float vSn;
                      

            return vSn = calcSbl - calcSa;
        }

        public float calcSs1(float calcSn)
        {
            float vSs1;


            return vSs1 = calcSn * Convert.ToSingle(0.3);
        }

        public float calcSs2(float calcSn)
        {
            float vSs2;
                 

            return vSs2 = calcSn * Convert.ToSingle( 0.7);
        }

        public float calcLl1(float AlturaLivre, float calcSs1)
        {
            return 0;
        }

        public float calcLl2(float AlturaLivre, float calcSs2)
        {
            float vLl2;
            //////
            return vLl2 = AlturaLivre;
        }

        public float calcPbl(float calcSbl, float calcConstElast)
        {
            return 0;
        }

        public float calcPn(float calcSn, float calConstElast)
        {
            return 0;
        }

        public float calcPp1(float calcSs1, float calcConstElast)
        {
            return 0;
        }

        public float calcPp2(float calcSs2, float calcConstElast)
        {
            return 0;
        }

        public float calcTbl(float DiamentroMedio, float calcPbl, float DiametroArame)
        {
            return 0;
        }

        public float calcTn(float DiamentroMedio, float calcPn, float DiametroArame)
        {
            return 0;
        }

        public float calcTt1(float DiamentroMedio, float calcPp1, float DiametroArame)
        {
            return 0;
        }

        public float calcTt2(float DiamentroMedio, float calcPp2, float DiametroArame)
        {
            return 0;
        }

        public float calcBarraTest(float DiamentroMedio, float calcCompFinal)
        {
            return 0;
        }

        public float calcBarraEnrolar(float calcCompFinal)
        {
            return 0;
        }

        public float calcPesoUnid(float DiamentroArame, float calcCompFinal)
        {
            return 0;
        }

        public float calcS1(float calcSs1)
        {
            return 0;
        }

        public float calcS2(float calcSs2)
        {
            return 0;
        }

        public float calcP1(float calcSs1, float calcConstElast)
        {
            return 0;
        }

        public void calcP2(float calcSs2, float calcConstElast)
        {

        }

        public float calcT1(float DiametroMedio, float calcP1, float DiametroArame)
        {
            return 0;
        }

        public float calcT2(float DiametroMedio, float calcP2, float DiametroArame)
        {
            return 0;
        }

        public bool avaliaT(float calcTbl, float calcTn, float calcTt1, float calcTt2, float calcT1, float calcT2)
        {
            return false;
        }

    }
}
