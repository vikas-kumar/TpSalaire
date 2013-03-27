using System;
using System.Collections.Generic;
using System.Text;

namespace tp_salaire
{
    class Ecran
    {
        public static void afficher(Salarie s)
        {            
            string sal = s.getnom();
            double salAnn = s.salaireAnnuel();
            
            Console.WriteLine(" Salarié :" + Convert.ToString(sal) + "\n Salaire Annuel NET :" + Convert.ToString(salAnn));
            
        }

        public static void afficherBulletins(Bulletin b)
        {
            Console.WriteLine("*************************************************");
            Console.WriteLine("Numero du mois :" + Convert.ToInt16(b.getMois()));
            Console.WriteLine("Salaire de base:" + (Convert.ToString(b.salaireBase())));
            Console.WriteLine("NbHS :" + (Convert.ToString(b.nbHS())));
            Console.WriteLine("MontanHS :" + (Convert.ToString(b.montantHS())));
            Console.WriteLine("SalaireBrut :" + (Convert.ToString(b.salaireBrut())));
            Console.WriteLine("RetenueSS :" + (Convert.ToString(b.retenueSS())));
            Console.WriteLine("RetenueChomage :" + (Convert.ToString(b.retenueChomage())));
            Console.WriteLine("RetenueCSG :" + (Convert.ToString(b.retenueCsg())));
            Console.WriteLine("Retenueretraite:" + (Convert.ToString(b.retenueRetraite())));
            Console.WriteLine("RetenuesTotal :" + (Convert.ToString(b.retenueTotales())));
            Console.WriteLine("SalaireNet :" + (Convert.ToString(b.salaireNet())));
        }

        public static void afficherNom(Salarie s)
        {
            string sal = s.getnom();

            Console.WriteLine(Convert.ToString(sal));

        }

        public static void afficherSal(Salarie s)
        {
            string sal = s.getnom();
            
            Console.WriteLine(" Salarié Trouvé :" + Convert.ToString(sal) );

        }

        public static void ajoutSal(string x)
        {
            
            Console.WriteLine("Le salarié " + x + " a bien été ajouté !");
        }

    }


     
        



    
}