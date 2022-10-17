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

namespace BarberShop.UI.Coiffeur
{
    /// <summary>
    /// Logique d'interaction pour FrmModificationCoiffeur.xaml
    /// </summary>
    public partial class FrmModificationCoiffeur : Window
    {
        public static Modeles.Coiffeur CoiffeurAModifier { get; set; }
        public FrmModificationCoiffeur()
        {
            InitializeComponent();
            Loaded += FrmModificationCoiffeur_Loaded;
        }

        private void FrmModificationCoiffeur_Loaded(object sender, RoutedEventArgs e)
        {
            // charger les infos dans les champs de saisies 
            if (CoiffeurAModifier != null)
            {
                txtIdCoiffeur.Text = CoiffeurAModifier.IdCoiffeur.ToString();
                txtNomCoiffeur.Text = CoiffeurAModifier.Nom;
                txtPrenomCoiffeur.Text = CoiffeurAModifier.Prenom;
                txtDateNaissanceCoiffeur.SelectedDate = CoiffeurAModifier.DateDeNaissance;
                txtSexeCoiffeur.Text = CoiffeurAModifier.Sexe.ToString();
                txtTelephoneCoiffeur.Text = CoiffeurAModifier.Telephone;
                txtEmailCoiffeur.Text = CoiffeurAModifier.Email;
                txtAdressePostaleCoiffeur.Text = CoiffeurAModifier.AdressePostale;
            }
        }

        private void btnModifierCoiffeur_Click(object sender, RoutedEventArgs e)
        {
            // Valider si les champs obligatoires sont bien remplis 
            if (string.IsNullOrWhiteSpace(txtNomCoiffeur.Text) || string.IsNullOrWhiteSpace(txtPrenomCoiffeur.Text) || string.IsNullOrWhiteSpace(txtTelephoneCoiffeur.Text)
                || string.IsNullOrWhiteSpace(txtEmailCoiffeur.Text) || string.IsNullOrWhiteSpace(txtSexeCoiffeur.Text))
            {
                MessageBox.Show("Merci de renseigner les champs avec un *", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                // Faire le update
                Modeles.Coiffeur coiffeur = new Modeles.Coiffeur(CoiffeurAModifier.IdCoiffeur, txtNomCoiffeur.Text, txtPrenomCoiffeur.Text, txtDateNaissanceCoiffeur.SelectedDate.Value, char.Parse(txtSexeCoiffeur.Text), txtTelephoneCoiffeur.Text, txtEmailCoiffeur.Text, txtAdressePostaleCoiffeur.Text);
                coiffeur.Modifier();

                DialogResult = true;
                this.Close();
            }           
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
