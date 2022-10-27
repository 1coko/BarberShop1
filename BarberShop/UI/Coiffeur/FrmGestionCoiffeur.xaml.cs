using BarberShop.UI.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace BarberShop.UI.Coiffeur
{
    /// <summary>
    /// Logique d'interaction pour FrmGestionCoiffeur.xaml
    /// </summary>
    public partial class FrmGestionCoiffeur : Window
    {
        // declaration de la liste ou de la collection itemSource de la grille
        public static ObservableCollection<Modeles.Coiffeur> itemSource;
        public FrmGestionCoiffeur()
        {
            InitializeComponent();
            // Initialiser, creation de l'objet
            itemSource = new ObservableCollection<Modeles.Coiffeur>();
        }

        // Evenement Loaded a faire sur l'ensmble de la fenetre Window du fichier WPF
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtRechercheCoiffeur.Focus();
            //// Remplir la grille 
            //MessageBox.Show("" +DateTime.MinValue);

            // Recuperer la liste des coiffeurs depuis la BD 
            Modeles.Coiffeur coiffeur = new Modeles.Coiffeur();
            List<Modeles.Coiffeur> resultatBD = coiffeur.Afficher();
            // Faire une boucle pour remplir notre variable itemsource (la collection qui sera passé plus tard a l'ItemSource de la grille
            foreach (var chaqueCoiffeur in resultatBD)
            {
                itemSource.Add(chaqueCoiffeur);
            }
            // Affecté l itemsource a la propriete ItemSource de la grille
            gridCoiffeur.ItemsSource = itemSource;
        }

        public void btnAjoutCoiffeur_Click(object sender, RoutedEventArgs e)
        {
            FrmAjoutCoiffeur frmAjoutCoiffeur = new FrmAjoutCoiffeur();
            frmAjoutCoiffeur.ShowDialog();
        }

        public void btnSupprimerCoiffeur_Click(object sender, RoutedEventArgs e)
        {
            // Verifier si l utilisateur a selectionné une ligne

            var ligneSelectionee = gridCoiffeur.SelectedItem as Modeles.Coiffeur;
            if (ligneSelectionee == null )
            {
                // Demander à l'utilisateur de selectionner une ligne
                MessageBox.Show("Merci de selectionner une ligne avant suppression!", "NOTE", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }

                var ligneSelectionee2 = gridCoiffeur.SelectedItem as Modeles.Coiffeur;
            if (ligneSelectionee2 != null)
            {
                // Demander a l'utilsateur sil veut vraiment supprimer (fenetre de confirmation)

                if (MessageBox.Show("Voulez-vous vraiment supprimer cette ligne ?", "ATTENTION", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    // Bouton Oui 


                    //ensuite supprimer la ligne selectionnée

                    ligneSelectionee.Supprimer();
                    itemSource.Remove(ligneSelectionee);
                }

            }


            Modeles.Client.CalculSomme();
        }

        public void btnModifierCoiffeur_Click(object sender, RoutedEventArgs e)
        {

            // Verifier si l'utilisateur a selectionné une ligne


            // Si oui on lui ouvre la fenetre de modification 

            //Sinon on lui affiche un msg box l'invitant a selectionner une ligne 

            Modeles.Coiffeur coiffeurSelectionnee = gridCoiffeur.SelectedItem as Modeles.Coiffeur;

            if (coiffeurSelectionnee != null)
            {
                // Affiche la fenetre 
                FrmModificationCoiffeur fenetreUpdate = new FrmModificationCoiffeur();
                FrmModificationCoiffeur.CoiffeurAModifier = coiffeurSelectionnee;
                if (fenetreUpdate.ShowDialog() == true)
                {
                    //// Remplir la grille 
                    //MessageBox.Show("" +DateTime.MinValue);

                    // Recuperer la liste des coiffeurs depuis la BD 
                    Modeles.Coiffeur coiffeur = new Modeles.Coiffeur();
                    List<Modeles.Coiffeur> resultatBD = coiffeur.Afficher();
                    itemSource.Clear();
                    // Faire une boucle pour remplir notre variable itemsource (la collection qui sera passé plus tard a l'ItemSource de la grille
                    foreach (var chaqueCoiffeur in resultatBD)
                    {
                        itemSource.Add(chaqueCoiffeur);
                    }
                    // Affecté l itemsource a la propriete ItemSource de la grille
                    gridCoiffeur.ItemsSource = itemSource;

                }
            }
            else
            {
                MessageBox.Show("Sélectionnez une ligne svp !", "ATTENTION", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        public void btnRefreshCoiffeur_Click(object sender, RoutedEventArgs e)
        {
            //// Remplir la grille 
            //MessageBox.Show("" +DateTime.MinValue);

            // Recuperer la liste des coiffeurs depuis la BD 
            Modeles.Coiffeur coiffeur = new Modeles.Coiffeur();
            List<Modeles.Coiffeur> resultatBD = coiffeur.Afficher();
            itemSource.Clear();
            // Faire une boucle pour remplir notre variable itemsource (la collection qui sera passé plus tard a l'ItemSource de la grille
            foreach (var chaqueCoiffeur in resultatBD)
            {
                itemSource.Add(chaqueCoiffeur);
            }
            // Affecté l itemsource a la propriete ItemSource de la grille
            gridCoiffeur.ItemsSource = itemSource;
        }

        public void txtRechercheCoiffeur_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Rechercher 
                Modeles.Coiffeur coiffeur = new Modeles.Coiffeur();
                List<Modeles.Coiffeur> resultat = coiffeur.Rechercher(txtRechercheCoiffeur.Text);

                itemSource.Clear();
                // On affiche chaque ligne recuperée dans la grille 

                foreach (var item in resultat)
                {
                    itemSource.Add(item);
                }

                // Passer a la grille la liste des donnees a afficher
                gridCoiffeur.ItemsSource = itemSource;
            }
        }
    }
}
