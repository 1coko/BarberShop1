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
            // Remplir la grille 
            MessageBox.Show("" +DateTime.MinValue);

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

        }

        public void btnUpdateCoiffeur_Click(object sender, RoutedEventArgs e)
        {

        }

        public void btnRefreshCoiffeur_Click(object sender, RoutedEventArgs e)
        {

        }

        public void txtRechercheCoiffeur_KeyDown(object sender, KeyEventArgs e)
        {
        
        }
    }
}
