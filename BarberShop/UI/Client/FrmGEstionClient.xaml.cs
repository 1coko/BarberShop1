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
    /// Interaction logic for FrmGEstionClient.xaml
    /// </summary>
    public partial class FrmGEstionClient : Window
    {
        public decimal Sauvegarde { get; set; }

        public static ObservableCollection<Modeles.Client> itemSource;   // declaration de la liste ou la collection itemSource de la grille
        public FrmGEstionClient()
        {
            InitializeComponent();
            itemSource = new ObservableCollection<Modeles.Client>();   // Initialiser, creation de l'objet 
        }


        // Evenement au chargement de la fenetre
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RemplirGrille();
            txtRecherche.Focus();
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();

            frmAjoutClient form = new frmAjoutClient();
            form.ShowDialog();
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            // Verifier si l utilisateur a selectionné une ligne 

            var ligneSelectionee = gridClients.SelectedItem as Modeles.Client;
            if(ligneSelectionee != null)
            {
                // Demander a l'utilsateur sil veut vraiment supprimer (fenetre de confirmation)

                if(MessageBox.Show("Voulez-vous vraiment supprimer cette ligne ?", "ATTENTION", MessageBoxButton.YesNo, MessageBoxImage.Question,MessageBoxResult.No)  == MessageBoxResult.Yes)
                {
                    // Bouton Oui 


                    //ensuite supprimer la ligne selectionnée

                    ligneSelectionee.Delete();
                    itemSource.Remove(ligneSelectionee);
                }

            }


            Modeles.Client.CalculSomme();

        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            // Verifier si l'utilisateur a selectionné une ligne 

            // Si oui on lui ouvre la fenetre de modification 

            //Sinon on lui affiche un msg box l'invitant a selectionner une ligne 

            Modeles.Client clientSelectionnee = gridClients.SelectedItem as Modeles.Client;

            if(clientSelectionnee != null)
            {
                // Affiche la fenetre 
                frmUpdateClient fenetreUpdate = new frmUpdateClient();
                frmUpdateClient.ClientAModifier = clientSelectionnee;
                if(fenetreUpdate.ShowDialog() == true)
                {
                    RemplirGrille();

                }
            }
            else
            {
                MessageBox.Show("Séelectionnez une ligne svp !", "ATTENTION", MessageBoxButton.OK, MessageBoxImage.Error);

            }



        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RemplirGrille();
        }

        public void RemplirGrille()
        {
            // rafrichir la grille

            //gridClients.Items.Refresh();   // a chercher 

            //On recupere les donnees de la BD
            Modeles.Client client = new Modeles.Client();
            List<Modeles.Client> resultat = client.Select();    // 11 lignes 
            itemSource.Clear();
            // On affiche chaque ligne recuperée dans la grille 

            foreach (var item in resultat)
            {
                itemSource.Add(item);
            }


            // Passer a la grille la liste des donnees a afficher
            gridClients.ItemsSource = itemSource;
        }

        private void txtRecherche_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                // Rechercher 
                Modeles.Client client = new Modeles.Client();
                List<Modeles.Client> resultat = client.Rechercher(txtRecherche.Text);

                itemSource.Clear();
                // On affiche chaque ligne recuperée dans la grille 

                foreach (var item in resultat)
                {
                    itemSource.Add(item);
                }

                // Passer a la grille la liste des donnees a afficher
                gridClients.ItemsSource = itemSource;
            }
        }

        private void btnReservation_Click(object sender, RoutedEventArgs e)
        {
            // verifier si un client est selectionné dans la grille 
            Modeles.Client clientSelectionnee = gridClients.SelectedItem as Modeles.Client;

            if (clientSelectionnee != null)
            {
                // Affiche la fenetre 
                frmReservationClient fenetreReserve = new frmReservationClient();
                frmReservationClient.ClientReservation = clientSelectionnee;
                if (fenetreReserve.ShowDialog() == true)
                {
                    RemplirGrille();
                    
                }
            }
            else
            {
                MessageBox.Show("Séelectionnez une ligne svp !", "ATTENTION", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }
    }
}
