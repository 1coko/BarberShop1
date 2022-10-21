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

        public Coiffeur()
        {
            
        }

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



        public static int ObtenirIdApartirDuNom(string nom)
        {
            int idCoiffeurAffiche = 0;
            SqlConnection con = null;
            List<Coiffeur> liste = new List<Coiffeur>();
            try
            {
                // Creation de la connexion  
                con = new SqlConnection("data source=51.79.69.136,1433; database=BarberShop; User ID = rock; Password = M0t2p@$$e");
                // la requete sql  

                string requete = string.Format("select * from Coiffeur where Nom = '{0}'", nom);

                SqlCommand cm = new SqlCommand(requete, con);
                // Ouvrir la connexion  
                con.Open();
                //  Executer la requete   
                SqlDataReader sdr = cm.ExecuteReader();
                // Iterating Data  
                while (sdr.Read())
                {
                    idCoiffeurAffiche = int.Parse(sdr["IdCoiffeur"].ToString());
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

            return idCoiffeurAffiche;
        }

        public List<Coiffeur> Afficher()
        {
            SqlConnection con = null;  // declaration de l'objet qui fait la connexion avec la BD
            List<Coiffeur> liste = new List<Coiffeur>();
            try
            {
                // Creation de l'objet de la connexion avec la chaine de connexion en parametre 

                con = new SqlConnection("data source=51.79.69.136,1433; database=BarberShop; User ID = rock; Password = M0t2p@$$e");
                // la requete sql  

                string requete = "select * from Coiffeur";

                // Permet de gerer la requete 
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
                    DateTime dateDeNaissance = DateTime.MinValue;
                    if (!sdr.IsDBNull(6))
                         dateDeNaissance = DateTime.Parse(sdr["DateDeNaissance"].ToString());
                    else
                        dateDeNaissance = DateTime.MinValue;

                    char sexe = char.Parse(sdr["Sexe"].ToString());
                    string telephone = sdr["Telephone"].ToString();
                    string Email = sdr["Email"].ToString();
                    string adressePostale = String.Empty;
                    if (!sdr.IsDBNull(5))
                        adressePostale = sdr["AdressePostale"].ToString();
                    else
                        adressePostale = null;



                    Coiffeur cf = new Coiffeur(idCoiffeur, nom, prenom, dateDeNaissance, sexe, telephone, Email, adressePostale);
                    liste.Add(cf);
                }

                Console.WriteLine("Succes");

            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, Erreur." + e.Message);
            }
            //Fermer la connexion  
            finally
            {
                con.Close();
            }

            return liste;
        }


        public void Modifier()
        {
            SqlConnection con = null;
            try
            {
                // Creation de la connexion  
                con = new SqlConnection("data source=51.79.69.136,1433; database=BarberShop; User ID = rock; Password = M0t2p@$$e");
                // la requete sql  

                string requete = string.Format("UPDATE Coiffeur SET Nom = '{0}', Prenom = '{1}', DatedeNaissance = '{2}', Sexe = '{3}', Telephone = '{4}', Email = '{5}', AdressePostale = '{6}' WHERE IdCoiffeur = {7}", Nom, Prenom, DateDeNaissance, Sexe, Telephone, Email, AdressePostale, IdCoiffeur);

                SqlCommand cm = new SqlCommand(requete, con);
                // Ouvrir la connexion  
                con.Open();
                // Executer la requete  
                cm.ExecuteNonQuery();
                Console.WriteLine("Ligne updatée");
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

        public void Supprimer()
        {
            SqlConnection con = null;
            try
            {
                // Creation de la connexion  
                con = new SqlConnection("data source=51.79.69.136,1433; database=BarberShop; User ID = rock; Password = M0t2p@$$e");
                // la requete sql  

                string requete = string.Format("DELETE FROM Coiffeur WHERE IdCoiffeur = {0}", IdCoiffeur);

                SqlCommand cm = new SqlCommand(requete, con);
                // Ouvrir la connexion  
                con.Open();
                // Executer la requete  
                cm.ExecuteNonQuery();
                Console.WriteLine("Ligne suprimée");
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

        public List<Coiffeur> Rechercher(string critereDeRecherche)
        {
            SqlConnection con = null;
            List<Coiffeur> liste = new List<Coiffeur>();
            try
            {
                // Creation de la connexion 
                con = new SqlConnection("data source=51.79.69.136,1433; database=BarberShop; User ID = rock; Password = M0t2p@$$e");

                // la requete sql  

                string requete = string.Format("select * from Coiffeur where Nom like '%{0}%' or Email like '%{0}%'", critereDeRecherche);

                SqlCommand cm = new SqlCommand(requete, con);
                //  Ouvrir la connexion  
                con.Open();
                //  Executer la requete   
                SqlDataReader sdr = cm.ExecuteReader();
                // Iterating Data  
                while (sdr.Read())
                {
                    int idCoiffeur = int.Parse(sdr["IdCoiffeur"].ToString());
                    string nom = sdr["Nom"].ToString();
                    string prenom = sdr["Prenom"].ToString();
                    DateTime dateDeNaissance = DateTime.MinValue;
                    if (!sdr.IsDBNull(6))
                        dateDeNaissance = DateTime.Parse(sdr["DateDeNaissance"].ToString());
                    else
                        dateDeNaissance = DateTime.MinValue;

                    char sexe = char.Parse(sdr["Sexe"].ToString());
                    string telephone = sdr["Telephone"].ToString();
                    string Email = sdr["Email"].ToString();
                    string adressePostale = String.Empty;


                    Coiffeur cof = new Coiffeur(idCoiffeur, nom, prenom, dateDeNaissance, sexe, telephone, Email, adressePostale);
                    liste.Add(cof);
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

        public static decimal CalculSomme()
        {
            decimal somme = 2 + 2;
            return somme;
        }

        public static decimal CalculPerinetre(int rayon)
        {
            return rayon * rayon;
        }
    }
}