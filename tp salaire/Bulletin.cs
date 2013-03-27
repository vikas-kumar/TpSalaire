using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace tp_salaire
{
    [System.Serializable]
    public class Bulletin
    {
        private int numMois;
        private double salaireHoraireBase;
        private ArrayList mesReleves = new ArrayList();

        
        public Bulletin(int numMois, double salaireHoraireBase)
        {
            this.numMois = numMois;
            this.salaireHoraireBase = salaireHoraireBase; 
        }

        public Bulletin()
        {
            this.numMois = 0;
            this.salaireHoraireBase = 0;
        }

        public int getMois()
        {
            return this.numMois;
        }

    

        public double salaireBase()
        {
            return 2275.05;
        }

        public double nbHS()
        {
            double w;
            w = 0;
            double x1;
            x1 = 0;

            foreach (ReleveHebdo x in this.mesReleves)
            {
                w = w + x.getnbHeures();
            }
            x1 = w - Parametre.horaireMensuelLegal();
            if (x1 < 0)
            {
                x1 = 0;
            }
            return x1;
        }

        public double montantHS()
        {
            double montant;
            if (this.nbHS() < Parametre.nbHSTranche1())
            {
                montant = this.nbHS() * (Parametre.tauxHoraireTranche1() * this.salaireHoraireBase);

            }
            else
            {
                montant = Parametre.nbHSTranche1() * (Parametre.tauxHoraireTranche1() * this.salaireHoraireBase);
                montant = montant + ((this.nbHS() - Parametre.nbHSTranche1()) * (Parametre.tauxHoraireTranche2() * this.salaireHoraireBase));
            }


            return montant;
        }

        public double salaireBrut()
        {
            double brut = this.salaireBase() +  this.montantHS(); 
            return brut;
        }

        public double retenueSS()
        {
            double ss = (this.salaireBrut() * Parametre.tauxRetenueSS());
            return ss;
        }

        public double retenueChomage()
        {
            double chom = (this.salaireBrut() * Parametre.tauxAssuranceChomage());
            return chom ;
        }

        public double retenueRetraite()
        {
            double ret;
            ret = 0;
            if (this.salaireBrut() < Parametre.plafond1Retraite())
            {
                 ret = (this.salaireBrut() * Parametre.tauxTranche1Retraite());
            }
            else
            {   ret = (Parametre.plafond1Retraite() * Parametre.tauxTranche1Retraite());
                if (this.salaireBrut() < Parametre.plafond2Retraite())
                 {
                      ret = ret + ((this.salaireBrut() - Parametre.plafond1Retraite()) * Parametre.tauxTranche2Retraite());
                 }
                   else
                 {
                      ret = ret + ((Parametre.plafond2Retraite() - Parametre.plafond1Retraite()) * Parametre.tauxTranche2Retraite());
                 }
            }
            return ret;
        }

        public double retenueCsg()
        {
            double csg = (this.salaireBrut() * Parametre.tauxRetenueCSG());
            return csg;
        }

        public double retenueTotales()
        {
            double total = this.retenueSS() + this.retenueChomage() + this.retenueRetraite() + this.retenueCsg();
            return total;
        }

        public double salaireNet()
        {
            double Net = this.salaireBrut() - this.retenueTotales();
            return Net;
        }


        private int getnumMois ()
        {
            return this.numMois;
        }

        private double getsalaireHoraireBase ()
        {
            return this.salaireHoraireBase;
        }

        public void ajouterReleve(int numero, double nbHeures)
        {
            ReleveHebdo a = new ReleveHebdo(numero, nbHeures);
            this.mesReleves.Add(a);
        }



    }
}
