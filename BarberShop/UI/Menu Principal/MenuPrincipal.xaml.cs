using BarberShop.UI.Client;
using BarberShop.UI.Coiffeur;
using System;
using System.Collections.Generic;
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

namespace BarberShop.UI.Menu_Principal
{
    /// <summary>
    /// Logique d'interaction pour MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        public void Button_Click_Client(object sender, RoutedEventArgs e)
        {
            FrmGEstionClient formGestClient = new FrmGEstionClient();
            formGestClient.Show();
        }

        public void Button_Click_Coiffeur(object sender, RoutedEventArgs e)
        {
            FrmGestionCoiffeur formGestCoiffeur = new FrmGestionCoiffeur();
            formGestCoiffeur.Show();
        }
    }
}
