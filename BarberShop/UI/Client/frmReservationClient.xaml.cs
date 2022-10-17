using BarberShop.Modeles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BarberShop.UI.Client
{
    /// <summary>
    /// Logique d'interaction pour frmReservationClient.xaml
    /// </summary>
    public partial class frmReservationClient : Window
    {
        public static Modeles.Client ClientReservation { get; set; }
        public ObservableCollection<string> listCoiffeurs { get; set; }
        public frmReservationClient()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
        }

        //private void FrmUpdateClient_Loaded(object sender, RoutedEventArgs e)
        //{
        //    // charger les infos dans les champs de saisies 
        //    if (ClientReservation != null)
        //    {
        //        txtNom.Text = ClientReservation.Nom;
        //        txtPrenom.Text = ClientReservation.Prenom;
        //    }

        //    // remplir la liste deroulante de coiffeur 

           


        //}

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            // Valider si les champs obligatoires sont bien remplis 
             // cbCoiffeur.SelectedIndex == -1



            // Dans la liste deroulante, recuperer l'id du coiffeur qui correspond au nom choisit

            string coiffeurSelectionne = cbCoiffeur.SelectedItem as string;
            if(coiffeurSelectionne != null)
            {
                // appeler une fonction qui prend en parametre le nom du coiffeur et nous retourne l'id corrspondant dans la BD

                int idCoiffeurDepuislaBD = Modeles.Coiffeur.ObtenirIdApartirDuNom(coiffeurSelectionne);


                // creer l'obet reservation avec les infos du formulaire 
                Reservation reserv = new Reservation(0,ClientReservation.Id, idCoiffeurDepuislaBD, );

                // enregistrer dans la base 

                // afficher un message box pour notifier l'utilisateur de la reservation 

            }





        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listCoiffeurs = new ObservableCollection<string>();

            if (ClientReservation != null)
            {
                txtNom.Text = ClientReservation.Nom;
                txtPrenom.Text = ClientReservation.Prenom;
            }

            // remplir la liste deroulante avec les coiffeurs 

            // recuperer la liste des coiffeurs de la BD 

            Modeles.Coiffeur coiffeur = new Modeles.Coiffeur();
            List<Modeles.Coiffeur> resultatBD = coiffeur.Afficher();
            // Faire une boucle pour remplir notre variable itemsource (la collection qui sera passé plus tard a l'ItemSource de la grille
            foreach (var chaqueCoiffeur in resultatBD)
            {
                listCoiffeurs.Add(chaqueCoiffeur.Nom);
            }

            // Affecter cette liste a l'itemsource de la liste deroulante 

            cbCoiffeur.ItemsSource = listCoiffeurs;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
