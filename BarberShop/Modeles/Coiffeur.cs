using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Modeles
{
    public class Coiffeur
    {
        //Variables
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public char Sex { get; set; }
        public int Telephone { get; set; }
        public string Mail { get; set; }
        public string AdressePostale { get; set; }


        //Constructeur
        public Coiffeur(int id, string nom, string prenom, DateTime dateDeNaissance, char sex, int telephone, string mail, string adressePostale)
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
        public void Cheveu()
        {
            Console.WriteLine("Bonjour,\nQuel coupe de cheveux souhaitez vous?");
        }
        public void Barbe()
        {
            Console.WriteLine("Bonjour,\nQuel coupe de barbe souhaitez vous?");
        }
        public void Soin()
        {
            Console.WriteLine("Bonjour,\nQuel soin souhaitez vous?");
        }
        public void Vente()
        {
            Console.WriteLine("Bonjour,\nBienvenu dans votre boutique dédié à votre bien-etre.\nQuel produit recherchez vous?");
        }
    }
}