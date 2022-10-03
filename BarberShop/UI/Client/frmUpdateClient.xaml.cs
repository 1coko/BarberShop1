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

namespace BarberShop.UI.Client
{
    /// <summary>
    /// Interaction logic for frmUpdateClient.xaml
    /// </summary>
    public partial class frmUpdateClient : Window
    {
        public static Modeles.Client ClientAModifier { get; set; }
        public frmUpdateClient()
        {
            InitializeComponent();
            Loaded += FrmUpdateClient_Loaded;
        }

        private void FrmUpdateClient_Loaded(object sender, RoutedEventArgs e)
        {
            // charger les infos dans les champs de saisies 
            if(ClientAModifier != null)
            {
                txtNom.Text = ClientAModifier.Nom;
                txtPrenom.Text = ClientAModifier.Prenom;
                txtDateNaissance.SelectedDate = ClientAModifier.DateDeNaissance;
                txtSexe.Text = ClientAModifier.Sex.ToString();
                txtTelephone.Text = ClientAModifier.Telephone;
                txtEmail.Text = ClientAModifier.Mail;
                txtAdressePostale.Text = ClientAModifier.AdressePostale;
                txtId.Text = ClientAModifier.Id.ToString();
            }
            

        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            // Valider si les champs obligatoires sont bien remplis 



            // Faire le update
            Modeles.Client client = new Modeles.Client(ClientAModifier.Id, txtNom.Text, txtPrenom.Text, txtDateNaissance.SelectedDate.Value, char.Parse(txtSexe.Text), txtTelephone.Text, txtEmail.Text, txtAdressePostale.Text);
            client.Update();
            
            DialogResult = true;
            this.Close();
        }
    }
}
