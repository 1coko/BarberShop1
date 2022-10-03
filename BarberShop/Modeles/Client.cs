using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Modeles
{
    public class Client
    {
        //Variable
    public int Id { get; set; }
    public string Nom {get;set;}
    public string Prenom { get; set; }
    public DateTime DateDeNaissance { get; set; }
    public char Sex { get; set; }
    public string Telephone { get; set; }
    public string Mail { get; set; }
    public string AdressePostale { get; set; }


        //Constructeur


        public Client()
        {

        }
    public Client (int id, string nom, string prenom, DateTime dateDeNaissance, char sex, string telephone, string mail, string adressePostale)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            DateDeNaissance = dateDeNaissance;
            Sex = sex;
            Telephone = telephone;
            Mail = mail;
            AdressePostale = adressePostale;
        }


       
        public void Insert()
        {
            SqlConnection con = null;
            try
            {
                // Creation de la connexion  
                con = new SqlConnection("data source=51.79.69.136,1433; database=BarberShop; User ID = rock; Password = M0t2p@$$e");
                // la requete sql  
                
                string requete = string.Format("INSERT INTO Client (Nom, Prenom, DateDeNaissance, Sex, Telephone, AdresseMail, AdressePostale) " +
                    "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", Nom, Prenom, DateDeNaissance, Sex, Telephone,Mail, AdressePostale);

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

        public void Update()
        {
            SqlConnection con = null;
            try
            {
                // Creation de la connexion  
                con = new SqlConnection("data source=51.79.69.136,1433; database=BarberShop; User ID = rock; Password = M0t2p@$$e");
                // la requete sql  

                string requete = string.Format("UPDATE Client SET Nom = '{0}', Prenom = '{1}', DateDeNaissance = '{2}', Sex = '{3}', Telephone = '{4}', AdresseMail = '{5}', AdressePostale = '{6}' WHERE IdClient = {7}", Nom, Prenom, DateDeNaissance, Sex, Telephone, Mail, AdressePostale, Id);

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

        public void Delete()
        {
            SqlConnection con = null;
            try
            {
                // Creation de la connexion  
                con = new SqlConnection("data source=51.79.69.136,1433; database=BarberShop; User ID = rock; Password = M0t2p@$$e");
                // la requete sql  

                string requete = string.Format("DELETE FROM Client WHERE IdClient = {0}", Id);

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

        public List<Client> Select()
        {
            SqlConnection con = null;
            List<Client> liste = new List<Client>();
            try
            {
                // Creation de la connexion 
                con = new SqlConnection("data source=51.79.69.136,1433; database=BarberShop; User ID = rock; Password = M0t2p@$$e");

                // la requete sql  
                SqlCommand cm = new SqlCommand("SELECT * FROM Client ", con);
                //  Ouvrir la connexion  
                con.Open();
                //  Executer la requete   
                SqlDataReader sdr = cm.ExecuteReader();
                // Iterating Data  
                while (sdr.Read())
                {
                    int id = int.Parse(sdr["IdClient"].ToString());
                    string nom = sdr["Nom"].ToString();
                    string prenom = sdr["Prenom"].ToString();
                    DateTime dateNaiss = DateTime.Parse(sdr["DateDeNaissance"].ToString());
                    char sex = char.Parse(sdr["Sex"].ToString());
                    string tel = sdr["Telephone"].ToString();
                    string mail = sdr["AdresseMail"].ToString();
                    string adr = sdr["AdressePostale"].ToString();



                    Client cl = new Client(id, nom, prenom, dateNaiss, sex, tel, mail, adr);
                    liste.Add(cl);
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


        public List<Client> Rechercher(string critereDeRecherche)
        {
            SqlConnection con = null;
            List<Client> liste = new List<Client>();
            try
            {
                // Creation de la connexion 
                con = new SqlConnection("data source=51.79.69.136,1433; database=BarberShop; User ID = rock; Password = M0t2p@$$e");

                // la requete sql  

                string requete = string.Format("select * from Client where Nom like '%{0}%' or AdresseMail  like '%{0}%'", critereDeRecherche);

                SqlCommand cm = new SqlCommand(requete, con);
                //  Ouvrir la connexion  
                con.Open();
                //  Executer la requete   
                SqlDataReader sdr = cm.ExecuteReader();
                // Iterating Data  
                while (sdr.Read())
                {
                    int id = int.Parse(sdr["IdClient"].ToString());
                    string nom = sdr["Nom"].ToString();
                    string prenom = sdr["Prenom"].ToString();
                    DateTime dateNaiss = DateTime.Parse(sdr["DateDeNaissance"].ToString());
                    char sex = char.Parse(sdr["Sex"].ToString());
                    string tel = sdr["Telephone"].ToString();
                    string mail = sdr["AdresseMail"].ToString();
                    string adr = sdr["AdressePostale"].ToString();



                    Client cl = new Client(id, nom, prenom, dateNaiss, sex, tel, mail, adr);
                    liste.Add(cl);
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

    }
}
