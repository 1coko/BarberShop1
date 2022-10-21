using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.ModelesAffichage
{
    public class MACOnsulationReservation
    {
        public string NomCoiffeur { get; set; }
        public string DateReservation { get; set; }
        public string HeureReservation { get; set; }
        public string NomClient { get; set; }
        public string TelephoneClient { get; set; }

        public MACOnsulationReservation(string nomCoiffeur, string dateReservation, string heureReservation, string nomClient, string telephoneClient)
        {
            NomCoiffeur = nomCoiffeur;
            DateReservation = dateReservation;
            HeureReservation = heureReservation;
            NomClient = nomClient;
            TelephoneClient = telephoneClient;
        }
    }
}
