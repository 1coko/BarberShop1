using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Modeles
{
    public class Coiffeur
    {
        //Variables
        public int IdCoiffeur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public char Sexe { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string AdressePostale { get; set; }


        //Constructeur
        public Coiffeur(int idCoiffeur, string nom, string prenom, DateTime dateDeNaissance, char sexe, string telephone, string email, string adressePostale)
        {
            IdCoiffeur = idCoiffeur;
            Nom = nom;
            Prenom = prenom;
            DateDeNaissance = dateDeNaissance;
            Sexe = sexe;
            Telephone = telephone;
            Email = email;
            AdressePostale = adressePostale;
        }


        //Fonction
        public void Créer()
        {
            SqlConnection con = null;
            try
            {
                // Creation de la connexion  
                con = new SqlConnection("data source=51.79.69.136,1433; database=BarberShop; User ID = rock; Password = M0t2p@$$e");
                // la requete sql  

                string requete = string.Format("insert into Coiffeur (Nom, Prenom, Telephone, Email, AdressePostale, DateDeNaissance, Sexe)" +
                    "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", Nom, Prenom, Telephone, Email, AdressePostale, DateDeNaissance, Sexe);

                SqlCommand cm = new SqlCommand(requete, con);
                // Ouvrir la connexion  
                con.Open();
                // Executer la requete  
                cm.ExecuteNonQuery();
                Console.WriteLine("Ligne inseree");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs,Erreur" + e);
            }
            // Fermer la connexion  
            finally
            {
                con.Close();
            }
        }



        public List<Coiffeur> Afficher()
        {
            SqlConnection con = null;
            List<Coiffeur> liste = new List<Coiffeur>();
            try
            {
                // Creation de la connexion  
                con = new SqlConnection("data source=51.79.69.136,1433; database=BarberShop; User ID = rock; Password = M0t2p@$$e");
                // la requete sql  

                string requete = string.Format("select * from Coiffeur where IdCoiffeur = {0})", IdCoiffeur);

                SqlCommand cm = new SqlCommand(requete, con);
                // Ouvrir la connexion  
                con.Open();
                //  Executer la requete   
                SqlDataReader sdr = cm.ExecuteReader();
                // Iterating Data  
                while (sdr.Read())
                {
                    int idCoiffeur = int.Parse(sdr["IdCoiffeur"].ToString());
                    string nom = sdr["Nom"].ToString();
                    string prenom = sdr["Prenom"].ToString();
                    DateTime dateDeNaissance = DateTime.Parse(sdr["DateDeNaissance"].ToString());
                    char sexe = char.Parse(sdr["Sexe"].ToString());
                    string telephone = sdr["Telephone"].ToString();
                    string Email = sdr["AdresseMail"].ToString();
                    string adressePostale = sdr["AdressePostale"].ToString();



                    Coiffeur cf = new Coiffeur(idCoiffeur, nom, prenom, dateDeNaissance, sexe, telephone, Email, adressePostale);
                    liste.Add(cf);
                }

                Console.WriteLine("Succes");

            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, Erreur." + e);
            }
            //Fermer la connexion  
            finally
            {
                con.Close();
            }

            return liste;
        }

    }
}