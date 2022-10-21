﻿using BarberShop.ModelesAffichage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Modeles
{
    public class Reservation
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdCoiffeur { get; set; }
        public DateTime DateReservation { get; set; }
        public string HeureReservation { get; set; }
        public bool ChampSupprime { get; set; }

        public Reservation()
        {

        }

        public Reservation(int id, int idclient, int idcoiffeur, DateTime datereservation, string heure, bool champSupprime)
        {
            Id = id;
            IdClient = idclient;
            IdCoiffeur = idcoiffeur;
            DateReservation = datereservation;
            HeureReservation = heure;
            ChampSupprime = champSupprime;

        }

        public Reservation(int id, int idclient, int idcoiffeur, DateTime datereservation, string heure)
        {
            Id = id;
            IdClient = idclient;
            IdCoiffeur = idcoiffeur;
            DateReservation = datereservation;
            HeureReservation = heure;
            ChampSupprime = false;

        }

        public void Insert()
        {
            SqlConnection con = null;
            try
            {
                // Creation de la connexion  
                con = new SqlConnection("data source=51.79.69.136,1433; database=BarberShop; User ID = rock; Password = M0t2p@$$e");
                // la requete sql  

                string requete = string.Format("insert into Reservation (IdClient, IdCoiffeur, DateReservation, HeureReservation ) " +
                    "VALUES ('{0}','{1}','{2}','{3}')", IdClient, IdCoiffeur, DateReservation.ToString("yyyy-MM-dd"), HeureReservation);

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
            //SqlConnection con = null;
            //try
            //{
            //    // Creation de la connexion  
            //    con = new SqlConnection("data source=51.79.69.136,1433; database=BarberShop; User ID = rock; Password = M0t2p@$$e");
            //    // la requete sql  

            //    string requete = string.Format("UPDATE Client SET Nom = '{0}', Prenom = '{1}', DateDeNaissance = '{2}', Sex = '{3}', Telephone = '{4}', AdresseMail = '{5}', AdressePostale = '{6}' WHERE IdClient = {7}", Nom, Prenom, DateDeNaissance, Sex, Telephone, Mail, AdressePostale, Id);

            //    SqlCommand cm = new SqlCommand(requete, con);
            //    // Ouvrir la connexion  
            //    con.Open();
            //    // Executer la requete  
            //    cm.ExecuteNonQuery();
            //    Console.WriteLine("Ligne updatée");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("OOPs,Erreur" + e);
            //}
            //// Fermer la connexion  
            //finally
            //{
            //    con.Close();
            //}
        }

        public void Delete()
        {
            //SqlConnection con = null;
            //try
            //{
            //    // Creation de la connexion  
            //    con = new SqlConnection("data source=51.79.69.136,1433; database=BarberShop; User ID = rock; Password = M0t2p@$$e");
            //    // la requete sql  

            //    string requete = string.Format("DELETE FROM Client WHERE IdClient = {0}", Id);

            //    SqlCommand cm = new SqlCommand(requete, con);
            //    // Ouvrir la connexion  
            //    con.Open();
            //    // Executer la requete  
            //    cm.ExecuteNonQuery();
            //    Console.WriteLine("Ligne suprimée");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("OOPs,Erreur" + e);
            //}
            //// Fermer la connexion  
            //finally
            //{
            //    con.Close();
            //}
        }

        public List<MACOnsulationReservation> Select()
        {
            SqlConnection con = null;
            List<MACOnsulationReservation> liste = new List<MACOnsulationReservation>();
            try
            {
                // Creation de la connexion 
                con = new SqlConnection("data source=51.79.69.136,1433; database=BarberShop; User ID = rock; Password = M0t2p@$$e");

                // la requete sql  
                SqlCommand cm = new SqlCommand("select c.Nom NomCoiffeur, b.DateReservation, b.HeureReservation,  a.Nom Nomclient, a.Telephone\r\nfrom Client a\r\njoin Reservation b on a.IdClient = b.IdClient \r\njoin Coiffeur c on b.IdCoiffeur = c.IdCoiffeur where DateReservation >=  CONVERT(varchar, GETDATE(),23)", con);
                //  Ouvrir la connexion  
                con.Open();
                //  Executer la requete   
                SqlDataReader sdr = cm.ExecuteReader();
                // Iterating Data  
                while (sdr.Read())
                {
                    string nomCoiffeur =sdr["NomCoiffeur"].ToString();
                    string dateReserv =sdr["DateReservation"].ToString();
                    string heurereserv = sdr["HeureReservation"].ToString();
                    string nomClient = sdr["NomClient"].ToString();
                    string telClient = sdr["Telephone"].ToString();

                    MACOnsulationReservation ma = new MACOnsulationReservation(nomCoiffeur, dateReserv, heurereserv, nomClient, telClient);
                    liste.Add(ma);
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

        // Rechercher la liste des clients
        public List<Client> Rechercher(string critereDeRecherche)
        {
            //SqlConnection con = null;
            //List<Client> liste = new List<Client>();
            //try
            //{
            //    // Creation de la connexion 
            //    con = new SqlConnection("data source=51.79.69.136,1433; database=BarberShop; User ID = rock; Password = M0t2p@$$e");

            //    // la requete sql  

            //    string requete = string.Format("select * from Client where Nom like '%{0}%' or AdresseMail  like '%{0}%'", critereDeRecherche);

            //    SqlCommand cm = new SqlCommand(requete, con);
            //    //  Ouvrir la connexion  
            //    con.Open();
            //    //  Executer la requete   
            //    SqlDataReader sdr = cm.ExecuteReader();
            //    // Iterating Data  
            //    while (sdr.Read())
            //    {
            //        int id = int.Parse(sdr["IdClient"].ToString());
            //        string nom = sdr["Nom"].ToString();
            //        string prenom = sdr["Prenom"].ToString();
            //        DateTime dateNaiss = DateTime.Parse(sdr["DateDeNaissance"].ToString());
            //        char sex = char.Parse(sdr["Sex"].ToString());
            //        string tel = sdr["Telephone"].ToString();
            //        string mail = sdr["AdresseMail"].ToString();
            //        string adr = sdr["AdressePostale"].ToString();



            //        Client cl = new Client(id, nom, prenom, dateNaiss, sex, tel, mail, adr);
            //        liste.Add(cl);
            //    }

            //    Console.WriteLine("Succes");

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("OOPs, Erreur." + e);
            //}
            ////Fermer la connexion  
            //finally
            //{
            //    con.Close();
            //}

            //return liste;
            return null;
        }

        public bool controleRdv (int idCoiffeur, string datereservation, string heurereservation)
        {
            string requeteRdvDejaPris = string.Format("select * FROM reservation WHERE IdCoiffeur = {0} and DateReservation = '{1}' and HeureReservation = '{2}'", idCoiffeur, datereservation, heurereservation);
            bool resultat = false;

            // executer la requete et ensuite retourner vrai ou faux en fonction du resultat.
            SqlConnection con = null;
            List<Client> liste = new List<Client>();
            try
            {
                // Creation de la connexion 
                con = new SqlConnection("data source=51.79.69.136,1433; database=BarberShop; User ID = rock; Password = M0t2p@$$e");

                // la requete sql  
                SqlCommand cm = new SqlCommand(requeteRdvDejaPris, con);
                //  Ouvrir la connexion  
                con.Open();
                //  Executer la requete   
                SqlDataReader sdr = cm.ExecuteReader();
                // Iterating Data  
                while (sdr.Read())
                {
                    resultat = true;
                }

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


            return resultat;

        }

    }
}
