using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Modeles
{
    public class Client
    {
        //Variables
    public int Id { get; set; }
    public string Nom {get;set;}
    public string Prenom { get; set; }
    public DateTime DateDeNaissance { get; set; }
    public char Sex { get; set; }
    public int Telephone { get; set; }
    public string Mail { get; set; }
    public string AdressePostale { get; set; }


        //Constructeur
    public Client (int id, string nom, string prenom, DateTime dateDeNaissance, char sex, int telephone, string mail, string adressePostale)
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


        //Fonction
    public void IdClient()
        {
            Console.WriteLine("Bonjour,\nBienvenue sur votre application BarberShop.\nMerci de vérifier vos informations avant de poursuivre.");
            Console.WriteLine("Nom : " + Nom);
            Console.WriteLine("Prénom : " + Prenom);
            Console.WriteLine("Date de naissance : " + DateDeNaissance);
            Console.WriteLine("Sex : " + Sex);
            Console.WriteLine("Telephone : " + Telephone);
            Console.WriteLine("Adresse email : " + AdressePostale);
            Console.WriteLine("Adresse posatale : " + AdressePostale);
        }

    }
}
