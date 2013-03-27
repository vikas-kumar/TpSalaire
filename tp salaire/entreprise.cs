using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace tp_salaire
{
    [System.Serializable]
    class entreprise
    {
        private string nomEntreprise;
        private ArrayList mesSalarie;

        public entreprise(string nomEntreprise)
        {
            this.nomEntreprise = nomEntreprise;
            mesSalarie = new ArrayList();
           
        }
        
        public entreprise()
        {
            this.nomEntreprise = "";
            mesSalarie = new ArrayList();
            
        }

        public Salarie getSalarieByName(string name)
        {
            
            foreach (Salarie s in this.mesSalarie)
            {
                if (s.getnom() == name)
                {
                    return s;
                }                }
                return null;
        }

    
        

        public void ajouterSalarieEnt(Salarie s)
        {
            this.mesSalarie.Add(s);
        }


        public void getMesSalaries()
        {
            foreach (Salarie s in this.mesSalarie)
            {
                Ecran.afficher(s);
            }          
        }

        public void countSal()
        {
            int x = this.mesSalarie.Count;
            Console.WriteLine(x);
        }

        public void getMesNoms()
        {
            foreach (Salarie s in this.mesSalarie)
            {
                Ecran.afficherNom(s);
            }
        }



        public bool verif(string nom)
        {
            bool x;
            x = false;
            foreach (Salarie v in this.mesSalarie)
            {
                if (v.getnom() == nom)
                {
                    x = true;
                }
            }
            
            return x;
        }



    }
}