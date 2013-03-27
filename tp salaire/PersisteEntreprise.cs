using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace tp_salaire
{
    [System.Serializable]
    class PersisteEntreprise
    {
        public static void Sauve(entreprise e)
        {
            FileStream fichier = new FileStream("Entreprise.txt", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fichier, e);
            fichier.Close();
        }


        public static entreprise Charger(string x)
        {
            FileStream fichier = new FileStream(x, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            entreprise e  = (entreprise)bf.Deserialize(fichier);
            fichier.Close();
            return e;
            
        }
    }
}
