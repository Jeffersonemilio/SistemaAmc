﻿using System;
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
            

            float valor = calcSn; // valor original
            float percentual =  Convert.ToSingle( 30 / 100.0); // 
            float valor_final = valor * percentual;

             float vSs1 =  valor_final  ;


            
            return vSs1;
        }

        public float calcSs2(float calcSn)
        {
            
            float valor = calcSn;
            float percentual = Convert.ToSingle(70 / 100.0);
            float valor_final = valor * percentual;
            float vSs2 = valor_final;

            return vSs2  ;
        }

        public float calcLl1(float AlturaLivre, float calcSs1)
        {
            float vLl1;

            return vLl1 = AlturaLivre - calcSs1;
        }

        public float calcLl2(float AlturaLivre, float calcSs2)
        {
            float vLl2;
            
            return vLl2 = AlturaLivre - calcSs2;
        }

        public float calcPbl(float calcSbl, float calcConstElast)
        {
            float vPbl;


            return vPbl = calcSbl * calcConstElast;
        }

        public float calcPn(float calcSn, float calcConstElast)
        {
            float vPn;


            return vPn = calcSn * calcConstElast;
        }

        public float calcPp1(float calcSs1, float calcConstElast)
        {
            float vPp1;


            return vPp1 = calcSs1 * calcConstElast;
        }

        public float calcPp2(float calcSs2, float calcConstElast)
        {
            float vPp2;


            return vPp2 = calcSs2 * calcConstElast;
        }

        public float calcTbl(float DiamentroMedio, float calcPbl, float DiametroArame)
        {
            float vDm, vPbl, vd, vTbl;
            vDm = DiamentroMedio;
            vPbl = calcPbl;
            vd = DiametroArame;

            vTbl = (8 * vDm * vPbl) / (Convert.ToSingle(Math.PI) * Convert.ToSingle(Math.Pow(vd, 3)));
            //vTbl = (8 * vDm * vPbl) / (Convert.ToSingle(Math.PI) * vd *  3);


            return vTbl;
        }

        public float calcTn(float DiamentroMedio, float calcPn, float DiametroArame)
        {
            float vDm, vPn, vd, vTn;
            vDm = DiamentroMedio;
            vPn = calcPn;
            vd = DiametroArame;

            vTn = (8 * vDm * vPn) / (Convert.ToSingle(Math.PI) * Convert.ToSingle(Math.Pow(vd, 3)));
            //vTn = (8 * vDm * vPn) / (Convert.ToSingle(Math.PI) * vd * 3);


            return vTn;
        }

        public float calcTt1(float DiamentroMedio, float calcPp1, float DiametroArame)
        {
            float vDm, vPp1, vd, vTt1;
            vDm = DiamentroMedio;
            vPp1 = calcPp1;
            vd = DiametroArame;

            vTt1 = (8 * vDm * vPp1) / (Convert.ToSingle(Math.PI) * Convert.ToSingle( Math.Pow( vd, 3)));


            return vTt1;
        }

        public float calcTt2(float DiamentroMedio, float calcPp2, float DiametroArame)
        {
            float vDm, vPp2, vd, vTt2;
            vDm = DiamentroMedio;
            vPp2 = calcPp2;
            vd = DiametroArame;

            vTt2 = (8 * vDm * vPp2) / (Convert.ToSingle(Math.PI) * Convert.ToSingle(Math.Pow(vd, 3)));
            //vTt2 = (8 * vDm * vPp2) / (Convert.ToSingle(Math.PI) * vd * 3);


            return vTt2;
        }

        public float calcBarraTest(float DiamentroMedio, float calcCompFinal)
        {
            float vDm, vCompFinal, vBarraTest;
            vDm = DiamentroMedio;
            vCompFinal = calcCompFinal;

            vBarraTest = (vDm * Convert.ToSingle(Math.PI) * Convert.ToSingle(1.5) + vCompFinal + 250); 

            return vBarraTest;
        }

        public float calcBarraEnrolar(float calcCompFinal)
        {
            float vBarraEnrolar;

            return  vBarraEnrolar = calcCompFinal + 250;
        }

        public double calcPesoUnid(float DiamentroArame, float calcCompFinal)
        {
            double vd, vCompFinal, vPesoUnid, vPi;
            vd = DiamentroArame;
            vCompFinal = calcCompFinal;
            
            vPesoUnid = (((((     Math.Pow((vd/2), 2)) * Math.PI) * 7.85) / Math.Pow(10, 3)) * vCompFinal / Math.Pow(10, 3));


            



            /*  Double p1, p2, p3, p4, p5, p6, p7, p8, p9;

            p1 = vd / 2;

            p2 = Math.Pow(p1, 2);

            p3 = p2 * Math.PI;

            p4 = p3 * 7.35;

            p5 = Math.Pow(10, 3);

            p6 = p4 / p5;

            p7 = p6 * vCompFinal;

            p8 = p5;

            p9 = p7 / p8; */


            //Não sei se essa formula vai dar certo ou errado...

            // NO EXCEL O PESO UNITARIO DE UMA MOLA É CALCULADO ASSIM: 
            // = (((((( vd /2 )^2 )*PI() ) * 7,85 ) / 10^3 )* vCompFinal   / 10^3)

            
        


            return vPesoUnid;
        }

        public float calcS1(float calcSs1)
        {
            
            float vSs1, vS1, valor;
            vSs1 = calcSs1;
            valor = vSs1;
          //  float percentual = Convert.ToSingle(0.05 / 100.0);
            
           float valor_final = valor + (Convert.ToSingle(0.05) * valor);


             vS1 = valor_final;

            return vS1;
        }

        public float calcS2(float calcSs2)
        {
            float vSs2, vS2, valor;
            vSs2 = calcSs2;
            valor = vSs2;
            float percentual = Convert.ToSingle(10 / 100.0);
            float valor_final = valor - (percentual * valor );
            vS2 = valor_final;

            return vS2;
        }

        public float calcP1(float calcS1, float calcConstElast)
        {
            float vSs1, vCalcCont, vP1;
            vSs1 = calcS1;
            vCalcCont = calcConstElast;
            vP1 = vSs1 * vCalcCont;


            return vP1;
        }

        public float calcP2(float calcS2, float calcConstElast)
        {
            float vSs2, vCalcCont, vP2;
            vSs2 = calcS2;
            vCalcCont = calcConstElast;
            vP2 = vSs2 * vCalcCont;


            return vP2;


        }

        public double calcT1(float DiametroMedio, float calcP1, float DiametroArame)
        {
            double vDm, vP1, vd, vT1;
            vDm = DiametroMedio;
            vP1 = calcP1;
            vd = DiametroArame;

            vT1 = (8 * vDm * vP1) / (Math.PI * Math.Pow(vd, 3));
           

            //Retorna Double
            return vT1;
        }

        public double calcT2(float DiametroMedio, float calcP2, float DiametroArame)
        {
            double vDm, vP2, vd, vT2;
            vDm = DiametroMedio;
            vP2 = calcP2;
            vd = DiametroArame;

            vT2 = (8 * vDm * vP2) / (Math.PI * Math.Pow(vd, 3));


            //Retorna Double
            return vT2;
        }

        public bool[] avaliaT(float calcTbl, float calcTn, float calcTt1, float calcTt2, float calcT1, float calcT2)
        {

           
            float vTbl, vTn, vTt1, vTt2, vT1, vT2;

            vTbl = calcTbl;
            vTn = calcTn;
            vTt1 = calcTt1;
            vTt2 = calcTt2;
            vT1 = calcT1;
            vT2 = calcT2;

            bool[] array = new bool[6];

            if (vTbl < 100)
            {
                array[0] = true;
            }
            else
            {
                array[0] = false;
            }

            if (vTn < 100)
            {
                array[1] = true;
            }
            else
            {
                array[1] = false;
            }

            if (vTt1 < 100)
            {
                array[2] = true;
            }
            else
            {
                array[2] = false;
            }

            if (vTt2 < 100)
            {
                array[3] = true;
            }
            else
            {
                array[3] = false;
            }

            if (vT1 < 100)
            {
                array[4] = true;
            }
            else
            {
                array[4] = false;
            }

            if (vT2 < 100)
            {
                array[5] = true;
            }
            else
            {
                array[5] = false;
            }


            return array;
        }

    }
}
