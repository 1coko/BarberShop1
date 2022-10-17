using BarberShop.Modeles;
using BarberShop.UI.Client;
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
    /// Logique d'interaction pour FrmAjoutCoiffeur.xaml
    /// </summary>
    public partial class FrmAjoutCoiffeur : Window
    {
        public FrmAjoutCoiffeur()
        {
            InitializeComponent();
        }

        public void btnAjouterCoiffeur_Click(object sender, RoutedEventArgs e)
        {
            // Verifier que les champs non null sont bien renseignés avant d'ajouter un coiffeur à la BDD
            if (string.IsNullOrWhiteSpace(txtNomCoiffeur.Text) || string.IsNullOrWhiteSpace(txtPrenomCoiffeur.Text) || string.IsNullOrWhiteSpace(txtTelephoneCoiffeur.Text)
                || string.IsNullOrWhiteSpace(txtEmailCoiffeur.Text) || string.IsNullOrWhiteSpace(txtSexeCoiffeur.Text))
            {
                MessageBox.Show("Merci de renseigner les champs avec un *", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                // Créer un objet "coiffeur" pour pouvoir renseigner les paramètres préparés dans le constructeur de la classe Coiffeur
                Modeles.Coiffeur coiffeur = new Modeles.Coiffeur(0, txtNomCoiffeur.Text, txtPrenomCoiffeur.Text, txtDateNaissanceCoiffeur.SelectedDate.Value, char.Parse(txtSexeCoiffeur.Text), txtTelephoneCoiffeur.Text, txtEmailCoiffeur.Text, txtAdressePostaleCoiffeur.Text);
                coiffeur.Créer();

                // Afficher un message de confirmation de l'ajout du coiffeur dans la BDD
                MessageBox.Show("Le coiffeur a bien été ajouté");


                // Ajouter la nouvelle ligne sur la grille WPF qui affiche les données de notre BDD

                // Variable static 
                if (FrmGestionCoiffeur.itemSource != null)
                    FrmGestionCoiffeur.itemSource.Add(coiffeur);

                this.Close();
            }
             
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
