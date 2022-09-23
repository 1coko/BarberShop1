using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BarberShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            {
            

            }
            
        }
    } 

}


namespace BarberShop.Modeles
{
    static void Main (string[] args)
    {
        Client Id = new Client("Abalo", "Koffi", 2020, 'M', 99775522, "abalo@koffi.com", "Lome_Prefecture_du_golfe");
        Id.IdClient();
    }
   
}
