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

        private char NomeTF;

        private char DataCreacao;

        private char Localizacao;

        private float DiametroInterno;

        private float DiametroArame;

        private float AlturaLivre;

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
            float vDe = vDi + (vd * 2);

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
            
            return 0;
        }

        public float calcCompFinal(float DiamentroMedio, float EspirasTotais)
        {
            return 0;
        }

        public float calcRelacEnrolamento(float DiamentroMedio, float DiametroArame)
        {
            return 0;
        }

        public bool avaliaRelacEnrolamento(float calcRelacEnrolamento)
        {
            return false;
        }

        public float calcIndEsbeltez(float AlturaLivre, float calcDiamMed)
        {
            return 0;
        }

        public bool avaliaIndEsbeltez(float calcIndEsbeltez)
        {
            return false;
        }

        public float calcConstElast(float Tmax, float DiamentroArame, float calcDiamMed, float calcEspUteis)
        {
            return 0;
        }

        public float calcSa(float calcDiamMed, float DiametroArame, int calcEspUteis)
        {
            return 0;
        }

        public float calcLbl(float EspirasTotais, float DiamentroArame)
        {
            return 0;
        }

        public float calcLn(float calcSa, float calcLbl)
        {
            return 0;
        }

        public void calcSbl(float calcLbl, float AlturaLivre)
        {

        }

        public float calcSn(float calcSbl, float calcSa)
        {
            return 0;
        }

        public float calcSs1(float calcSn)
        {
            return 0;
        }

        public float calcSs2(float calcSn)
        {
            return 0;
        }

        public float calcLl1(float AlturaLivre, float calcSs1)
        {
            return 0;
        }

        public float calcLl2(float AlturaLivre, float calcSs2)
        {
            return 0;
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
