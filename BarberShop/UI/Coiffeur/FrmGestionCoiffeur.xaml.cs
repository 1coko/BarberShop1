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

            // rafrichir la grille

            //gridClients.Items.Refresh();   // a chercher 

            //On recupere les donnees de la BD

            //Modeles.Coiffeur coiffeur = new Modeles.Coiffeur();
            //List<Modeles.Coiffeur> resultat = Coiffeur.Select(); 
            //itemSource.Clear();

            // On affiche chaque ligne recuperée dans la grille 

            //foreach (var item in resultat)
            //{
            //    itemSource.Add(item);
            //}


            // Passer a la grille la liste des donnees a afficher
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
