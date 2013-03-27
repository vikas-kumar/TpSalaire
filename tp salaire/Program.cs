using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

namespace tp_salaire
{
    [System.Serializable] 
    public class Appsalaire
    {
        static entreprise e;

        static void Main(string[] args)
        {
            
            e = PersisteEntreprise.Charger("Entreprise.txt");
            run();
        }

    
          /*  Bulletin b1 = new Bulletin(1, 16);
            b1.ajouterReleve(1, 35);
            b1.ajouterReleve(2, 39);
            b1.ajouterReleve(3, 35);
            b1.ajouterReleve(4, 41);
            Bulletin b2 = new Bulletin(2, 16);
            b2.ajouterReleve(1, 39);
            b2.ajouterReleve(2, 38);
            b2.ajouterReleve(3, 43);
            b2.ajouterReleve(4, 41);
            Bulletin b3 = new Bulletin(3, 16);
            b3.ajouterReleve(1, 39);
            b3.ajouterReleve(2, 38);
            b3.ajouterReleve(3, 43);
            b3.ajouterReleve(4, 41);
            Bulletin b4 = new Bulletin(4, 17);
            b4.ajouterReleve(1, 35);
            b4.ajouterReleve(2, 40);
            b4.ajouterReleve(3, 35);
            b4.ajouterReleve(4, 38);
            
            Salarie s = new salarie("toto");
            s.ajouterBulletin(b1);
            s.ajouterBulletin(b2);
            s.ajouterBulletin(b3);
            s.ajouterBulletin(b4);
            
            PersisteSalarie.Sauve(s);*/
       
            public static void run()
            {
        
                  char choix = ' ';
                  while (choix != 'q')

                  {

                    afficherMenu();

                    choix = Console.ReadLine()[0];

                    traiter(choix);

                    }

            }

            public static void afficherMenu()
            {
                    Console.WriteLine("*****************************************************");
               
                    Console.WriteLine("*    a : Affiche les salariés de l'entreprise       *");

                    Console.WriteLine("*    b : Afficher bulletins d'un salarié            *");

                    Console.WriteLine("*    c : Ajouter un salarié                         *");

                    Console.WriteLine("*    d : Ajouter Bulletin d'un salarié existant     *");

                    Console.WriteLine("*    e : Supprimer un bulletin                      *");

                    Console.WriteLine("*    q : Enregistrer et Quitter                     *");
                    
                    Console.WriteLine("*****************************************************");
            }

            public static void traiter(char c)
            {

                    switch (c)
                    {       
                       
                            case 'a':
                            {
                            e.getMesSalaries();
                                
                            break; 
                            }

                        case 'b': 
                            {
                                string name;                                
                                Console.WriteLine("Entrez le nom du salarié recherché :");
                                name = Console.ReadLine();
                                bool test = e.verif(name);

                                while (test == false)
                                {
                                    Console.WriteLine("Le nom entré n'existe pas, veuillez resaisir");
                                    name = Console.ReadLine();
                                    test = e.verif(name);
                                }
                                Salarie leSalarie = e.getSalarieByName(name);

                                ArrayList bull = leSalarie.getLesBulletins();                             

                                foreach (Bulletin b in bull)
                                {
                                    Ecran.afficherBulletins(b);
                                }
                                

                                break;
                            }

                            

                            case 'c':
                            {
                                
                               
                                Console.WriteLine("Entrez le nom du salarié à ajouter :");
                                    string nom = Console.ReadLine();
                                    bool test = e.verif(nom);

                                    while (test == true)
                                    {
                                        Console.WriteLine("Le nom existe déjà, veuillez resaisir un nom");
                                        nom = Console.ReadLine();
                                        test = e.verif(nom);
                                    }

                                    Salarie s = new Salarie(nom);
                                    e.ajouterSalarieEnt(s);
                                    Ecran.ajoutSal(nom);
                                    break;
                            }



                        case 'd': 
                            {
                                Console.WriteLine("Entrer le nom du salarié dont vous souhaitez ajouter un bulletin");
                                string nom = Console.ReadLine();
                                bool test = e.verif(nom);
                                while (test == false)
                                {
                                    Console.WriteLine("Le nom entré est incorrect, veuillez resaisir");
                                    nom = Console.ReadLine();
                                    test = e.verif(nom);
                                }
                                Salarie s = e.getSalarieByName(nom);


                                int mois;
                                if (s.moisMax() == 0)
                                {
                                    Console.WriteLine("Veuillez entrer le mois du bulletin a ajouter svp");
                                    int m = Convert.ToInt16( Console.ReadLine());
                                    mois = m + s.moisMax();
                                }
                                else
                                {
                                    mois = s.moisMax() + 1;
                                }


                                Console.WriteLine("Entrez le salaire horaire base :");
                                double salbase = Convert.ToDouble(Console.ReadLine());

                                Bulletin b = new Bulletin(mois, salbase);

                                for (int i = 1; i < 5; i++)
                                {
                                    Console.WriteLine("Entrez le relevé {0}:", i);
                                    int nbheure = Convert.ToInt16(Console.ReadLine());
                                    b.ajouterReleve(i, nbheure);

                                }

                                s.ajouterBulletin(b); 
                                break;
                            }





                        case 'e':
                            {
                                Console.WriteLine("Entrez le nom du salarié sur lequel vous souhaitez supprimer un bulletin");
                                string nom = Console.ReadLine();
                                bool verif = e.verif(nom);
                                while (verif == false)
                                {
                                    Console.WriteLine("Le nom entré n'existe pas, resaisir nom");
                                    nom = Console.ReadLine();
                                    verif = e.verif(nom);
                                }

                                Salarie salar = e.getSalarieByName(nom);
                                ArrayList bull = salar.getLesBulletins();
                                foreach (Bulletin b in bull)
                                {
                                    Ecran.afficherBulletins(b);
                                }

                                Console.WriteLine("Veuillez entrer le mois à supprimer");
                                int mois = Convert.ToInt16(Console.ReadLine());

                                while (mois > 12)
                                {
                                    Console.WriteLine("Le mois entré est incorrect, resaisir mois svp");
                                    mois = Convert.ToInt16(Console.ReadLine());
                                }

                                salar.supprimerlebulletin(mois);



                                break;
                            }

                                                   
                       case 'q': 
                           {
                               PersisteEntreprise.Sauve(e);
                               Console.Clear();
                               Console.WriteLine("Au Revoir..."); 
                               break; 
                           }
                     

                    }

            }

           

        } 
    }