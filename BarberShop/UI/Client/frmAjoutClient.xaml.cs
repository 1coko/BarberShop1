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
using BarberShop.Modeles;

namespace BarberShop.UI.Client
{
    /// <summary>
    /// Interaction logic for frmAjoutClient.xaml
    /// </summary>
    public partial class frmAjoutClient : Window
    {
        public frmAjoutClient()
        {
            InitializeComponent();
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            // Vérifie si les champs qui doivent etre non null sont renseignés 

            // Si c'est bon , on enregistre dans la BD 
            Modeles.Client client = new Modeles.Client(0, txtNom.Text, txtPrenom.Text, txtDateNaissance.SelectedDate.Value, char.Parse(txtSexe.Text), txtTelephone.Text, txtEmail.Text, txtAdressePostale.Text);
            client.Insert();


            //client.Select();
            MessageBox.Show("Le client a bien été ajouté");


            // Ajouter la nouvelle ligne inseree a la grille
            // 
            // Variable static 
            if(FrmGEstionClient.itemSource != null)
                FrmGEstionClient.itemSource.Add(client);


            this.Close();


            // Sinon on affiche un messageBox pour dire a l'utilsateur de remplir les champs necessaires

        }
    }
}
