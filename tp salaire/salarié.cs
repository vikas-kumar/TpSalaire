using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace tp_salaire
{
    [System.Serializable] 
    public class Salarie
    {
        private string nom;
        private ArrayList mesBulletin = new ArrayList();

        public Salarie(string nom)
        {
            this.nom = nom;
        }
        

        public Salarie()
        {
            this.nom = "";
        }

        public ArrayList getLesBulletins()
        {
            return this.mesBulletin;
        }

        public string getnom()
        {
            return this.nom;
        }

        public int moisMax()
        {
            return this.mesBulletin.Count;
        }

        public void ajouterBulletin(Bulletin b)
        {            
            this.mesBulletin.Add(b);
        }

        public double salaireAnnuel()
        {
            double c;
            c = 0;
            foreach (Bulletin b in this.mesBulletin)
            {
                c = c + b.salaireNet(); 
            }
            return c;
        }

        public double salaireAnnBrut()
        {
            double c;
            c = 0;
            foreach (Bulletin b in this.mesBulletin)
            {
                c = c + b.salaireBrut();
            }
            return c;
        }

        public void supprimerlebulletin(int nummois)
        {

            Bulletin b1 = new Bulletin();

            foreach (Bulletin b in this.getLesBulletins())
            {
                if (b.getMois() == nummois)
                {
                    b1 = b;
                }

            }

            this.mesBulletin.Remove(b1);
        }
    }
}
