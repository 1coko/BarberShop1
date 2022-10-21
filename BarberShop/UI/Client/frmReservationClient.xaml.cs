using BarberShop.Modeles;
using BarberShop.UI.Coiffeur;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        private void btnReserver_Click(object sender, RoutedEventArgs e)
        {
            int idCoiffeurDepuislaBD = 0;
            // Valider si les champs obligatoires sont bien remplis

            // Dans la liste deroulante, recuperer l'id du coiffeur qui correspond au nom choisit

            string coiffeurSelectionne = cbCoiffeur.SelectedItem as string;
            if (cbCoiffeur.SelectedIndex == -1 || dateReservation.SelectedDate == null || string.IsNullOrWhiteSpace(txtHeure.Text))
            {              

                //if (coiffeurSelectionne != null)
                //{
                // afficher un message box pour notifier l'utilisateur de reseigner tous les champs

                MessageBox.Show("Merci de selectionner un coiffeur, dans la liste déroulante \"Coiffeur cible\" et/ou de renseigner les champs \"Date de reservation\" et \"Heure de reservation\"", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                //}
            }

            else
            {
                try
                {
                    // Verifier si la date de reservation n'est pas inferieure a la date du jour 

                    //date du jour en c sharp : DateTime.Now
                    if (dateReservation.SelectedDate.Value.Date < DateTime.Now.Date)
                    {
                        MessageBox.Show("Merci de selectionner une \"Date de reservation\" suppérieur ou égale à la date jour", "MESSAGE", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                    else 
                    {
                        // appeler une fonction qui prend en parametre le nom du coiffeur et nous retourne l'id corrspondant dans la BD

                        idCoiffeurDepuislaBD = Modeles.Coiffeur.ObtenirIdApartirDuNom(coiffeurSelectionne);

                  


                        // creer l'objet reservation avec les infos du formulaire 
                        //string heureMinutes = txtHeure.Text + ":" + txtMinutes.Text;
                        string heureMinutes = string.Format("{0}:{1}", txtHeure.Text, txtMinutes.Text);
                        Reservation reserv = new Reservation(0, ClientReservation.Id, idCoiffeurDepuislaBD, dateReservation.SelectedDate.Value, heureMinutes);


                        // verifier si ce coiffeur a un rdv a cette periode 

                        bool resulatDeVerification = reserv.controleRdv(idCoiffeurDepuislaBD, dateReservation.SelectedDate.Value.ToString("yyyy-MM-dd"), heureMinutes);

                        if(resulatDeVerification == false)
                        {
                            // enregistrer dans la base

                            reserv.Insert();

                            // afficher un message box pour notifier l'utilisateur de la reservation

                            string messageAEnvoyer = "Bonjour," + ClientReservation.Nom + "\n Votre reservation du : " + dateReservation.SelectedDate + "à" + heureMinutes + "H, a bien été enregistrée.\n A très bientôt dans votre salon.";
                            MessageBox.Show(messageAEnvoyer);


                            // Envoie un courriel 

                            //Utilitaires.EnvoyerEmail(messageAEnvoyer,ClientReservation.Mail);

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Merci de selectionner un autre creneau horaire !", "MESSAGE", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                       

                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
