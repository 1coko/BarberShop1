using BarberShop.ModelesAffichage;
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

namespace BarberShop.UI.ConsulterReservation
{
    /// <summary>
    /// Logique d'interaction pour frmConsultationReservation.xaml
    /// </summary>
    public partial class frmConsultationReservation : Window
    {
        public static ObservableCollection<MACOnsulationReservation> itemSource;
        public frmConsultationReservation()
        {
            InitializeComponent();
            itemSource = new ObservableCollection<MACOnsulationReservation>();

            Loaded += FrmConsultationReservation_Loaded;
        }

        private void FrmConsultationReservation_Loaded(object sender, RoutedEventArgs e)
        {
            //// Remplir la grille 
            //MessageBox.Show("" +DateTime.MinValue);

            // Recuperer la liste des coiffeurs depuis la BD 
            Modeles.Reservation reservation = new Modeles.Reservation();
            List<MACOnsulationReservation> resultatBD = reservation.Select();
            // Faire une boucle pour remplir notre variable itemsource (la collection qui sera passé plus tard a l'ItemSource de la grille
            foreach (var item in resultatBD)
            {
                itemSource.Add(item);
            }
            // Affecté l itemsource a la propriete ItemSource de la grille
            gridReservation.ItemsSource = itemSource;
        }
    }
}
