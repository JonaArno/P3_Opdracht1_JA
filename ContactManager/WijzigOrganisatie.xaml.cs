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
using ContactManager.AdoConnected;
using ContactManager.Business;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for WijzigOrganisatie.xaml
    /// </summary>
    public partial class WijzigOrganisatie : Window
    {
        //bij _oorspronkelijkeOrganisatie instantiëring weggenomen wegens niet noodzakelijk (houdt ref in)
        private Organisatie _oorspronkelijkeOrganisatie;
        private Telefoon _geselecteerdeTelefoon;
        public Persoon ContactPersoon { get; set; }

        public WijzigOrganisatie(Organisatie teWijzigenOrganisatie)
        {
            InitializeComponent();

            TeWijzigenOrganisatieNaamTextBox.Text = teWijzigenOrganisatie.Naam;
            TeWijzigenOrganisatieStraatTextBox.Text = teWijzigenOrganisatie.Adres.Straat;
            TeWijzigenOrganisatieLocatieTextBox.Text = teWijzigenOrganisatie.Adres.Locatie;
            TeWijzigenOrganisatieLandTextBox.Text = teWijzigenOrganisatie.Adres.Land;

            if (teWijzigenOrganisatie.ContactPersoon != null)
            {
                HeeftContactPersoonCheckBox.IsChecked = true;
                GeselecteerdeContactTextBox.Text = teWijzigenOrganisatie.ContactPersoon.Naam;
            }

            if (HeeftContactPersoonCheckBox.IsChecked == false)
            {
                SelecteerContactPersoonButton.Foreground = Brushes.Gray;
                SelecteerContactPersoonButton.IsHitTestVisible = false;
                GeselecteerdeContactTextBox.IsHitTestVisible = false;
            }
            
            TelefoonOverzichtListView.ItemsSource = teWijzigenOrganisatie.Telefoons;

            _oorspronkelijkeOrganisatie = teWijzigenOrganisatie;
        }

        private void OnHeeftContactPersoonCheckboxClick(object sender, RoutedEventArgs e)
        {
            if (HeeftContactPersoonCheckBox.IsChecked == false)
            {
                SelecteerContactPersoonButton.Foreground = Brushes.Gray;
                SelecteerContactPersoonButton.IsHitTestVisible = false;
                GeselecteerdeContactTextBox.IsHitTestVisible = false;
                GeselecteerdeContactTextBox.Text = string.Empty;
            }
            
            else if (HeeftContactPersoonCheckBox.IsChecked == true)
            {
                SelecteerContactPersoonButton.Foreground = Brushes.Blue;
                SelecteerContactPersoonButton.IsHitTestVisible = true;
                GeselecteerdeContactTextBox.IsHitTestVisible = true;
            }

        }

        private void BewaarWijzigOrganisatieWijzigingenButton_Click(object sender, RoutedEventArgs e)
        {
            var cs = new ContactStore();

            if (_oorspronkelijkeOrganisatie.Naam == TeWijzigenOrganisatieNaamTextBox.Text &&
                _oorspronkelijkeOrganisatie.Adres.Straat == TeWijzigenOrganisatieStraatTextBox.Text &&
                _oorspronkelijkeOrganisatie.Adres.Locatie == TeWijzigenOrganisatieLocatieTextBox.Text &&
                _oorspronkelijkeOrganisatie.Adres.Land == TeWijzigenOrganisatieLandTextBox.Text &&
                _oorspronkelijkeOrganisatie.ContactPersoon.Naam == ContactPersoon.Naam &&
                _oorspronkelijkeOrganisatie.Telefoons.Equals(TelefoonOverzichtListView.ItemsSource))
            {
                this.Close();
            }
            else
            {
                _oorspronkelijkeOrganisatie.Naam = TeWijzigenOrganisatieNaamTextBox.Text;
                _oorspronkelijkeOrganisatie.Adres.Straat = TeWijzigenOrganisatieStraatTextBox.Text;
                _oorspronkelijkeOrganisatie.Adres.Locatie = TeWijzigenOrganisatieLocatieTextBox.Text;
                _oorspronkelijkeOrganisatie.Adres.Land = TeWijzigenOrganisatieLandTextBox.Text;

                _oorspronkelijkeOrganisatie.ContactPersoon = ContactPersoon;

                //telefoons-collectie wordt al aangepast met de buttons daar, dus niet nodig op deze plaats

                cs.Wijzig(_oorspronkelijkeOrganisatie);
            }
        }

        private void AnnuleerWijzigOrganisatieWijzigingenButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnVerwijderGelecteerdeTefoonButtonClick(object sender, RoutedEventArgs e)
        {
            _oorspronkelijkeOrganisatie.Telefoons.Remove(_geselecteerdeTelefoon);
            //refresh noodzakelijk?
            TelefoonOverzichtListView.ItemsSource = _oorspronkelijkeOrganisatie.Telefoons;
        }

        private void UpdateGewijzigdTelefoonNummerButton_Click(object sender, RoutedEventArgs e)
        {
            Telefoon tel = new Telefoon() {TelefoonType = TeWijzigenTelefoonNaamTextBox.Text, Nummer = TeWijzigenTelefoonNummerTextBox.Text};
            _oorspronkelijkeOrganisatie.Telefoons.Add(tel);

            //is deze refresh wel nodig om de listview te updaten?
            TelefoonOverzichtListView.ItemsSource = _oorspronkelijkeOrganisatie.Telefoons;

            //leeg maken van invoervelden na opslag
            TeWijzigenTelefoonNaamTextBox.Text = string.Empty;
            TeWijzigenTelefoonNummerTextBox.Text = string.Empty;
        }

        private void SelecteerContactPersoonButton_Click(object sender, RoutedEventArgs e)
        {
            var selecteerContactVenster = new ZoekVenster(this);
            selecteerContactVenster.ShowDialog();
        }

        private void OnTelefoonOverzichtSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _geselecteerdeTelefoon = e.AddedItems[0] as Telefoon;
        }        
    }
}
