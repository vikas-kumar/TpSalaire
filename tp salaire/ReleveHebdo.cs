using System;
using System.Collections.Generic;
using System.Text;

namespace tp_salaire
{
    [System.Serializable] 
    public class ReleveHebdo
    {
        private int numero;
        private double nbHeures;

        public ReleveHebdo(int numero, double nbHeures)
        {
            this.numero = numero;
            this.nbHeures = nbHeures;
        }

        public ReleveHebdo()
        {
            this.numero = 0;
            this.nbHeures = 0;
        }

        public int getnumero()
        {
            return this.numero;
        }
        public double getnbHeures()
        {
            return nbHeures;
        }



    }
}