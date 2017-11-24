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
    /// Interaction logic for WijzigPersoon.xaml
    /// </summary>
    public partial class WijzigPersoon : Window
    {
        //moet dit wel geïnstantieerd worden?
        private Persoon _oorspronkelijkePersoon = new Persoon();
        private Telefoon _geselecteerdeTelefoon = new Telefoon();

        public WijzigPersoon(Persoon teWijzigenPersoon)
        {
            InitializeComponent();

            TeWijzigenPersoonNaamTextBox.Text = teWijzigenPersoon.Naam;
            TeWijzigenPersoonStraatTextBox.Text = teWijzigenPersoon.Adres.Straat;
            TeWijzigenPersoonLocatieTextBox.Text = teWijzigenPersoon.Adres.Locatie;
            TeWijzigenPersoonLandTextBox.Text = teWijzigenPersoon.Adres.Land;

            if (teWijzigenPersoon.GeboorteDatum != null) GeboorteDatumCheckBox.IsChecked = true;
            TeWijzigenPersoonGeboortedatumDatePicker.Text = teWijzigenPersoon.GeboorteDatum.ToString();

            if (GeboorteDatumCheckBox.IsChecked == false)
            {
                TeWijzigenPersoonGeboortedatumDatePicker.IsHitTestVisible = false;
            }

            TelefoonOverzichtListView.ItemsSource = teWijzigenPersoon.Telefoons;

            _oorspronkelijkePersoon = teWijzigenPersoon;
        }

        private void OnTelefoonNummerVerwijderenButtonClick(object sender, RoutedEventArgs e)
        {
            _oorspronkelijkePersoon.Telefoons.Remove(_geselecteerdeTelefoon);
        }

        private void UpdateGewijzigdTelefoonNummerButton_Click(object sender, RoutedEventArgs e)
        {
            //update listview van telefoonnummers
        }

        private void AnnuleerWijzigPersoonWijzigingenButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BewaarWijzigPersoonWijzigingenButton_Click(object sender, RoutedEventArgs e)
        {
            var cs = new ContactStore();

            if (_oorspronkelijkePersoon.Naam == TeWijzigenPersoonNaamTextBox.Text &&
                _oorspronkelijkePersoon.Adres.Straat == TeWijzigenPersoonStraatTextBox.Text &&
                _oorspronkelijkePersoon.Adres.Locatie == TeWijzigenPersoonLocatieTextBox.Text &&
                _oorspronkelijkePersoon.Adres.Land == TeWijzigenPersoonLandTextBox.Text &&
                _oorspronkelijkePersoon.GeboorteDatum.ToString() == TeWijzigenPersoonGeboortedatumDatePicker.Text &&
                _oorspronkelijkePersoon.Telefoons.Equals(TelefoonOverzichtListView.ItemsSource))
            {
                this.Close();
            }
            else
            {
                _oorspronkelijkePersoon.Naam = TeWijzigenPersoonNaamTextBox.Text;
                _oorspronkelijkePersoon.Adres.Straat = TeWijzigenPersoonStraatTextBox.Text;
                _oorspronkelijkePersoon.Adres.Locatie = TeWijzigenPersoonLocatieTextBox.Text;
                _oorspronkelijkePersoon.Adres.Land = TeWijzigenPersoonLandTextBox.Text;

                //testen op geldige invoer?
                _oorspronkelijkePersoon.GeboorteDatum = DateTime.Parse(TeWijzigenPersoonGeboortedatumDatePicker.Text);

                //telefoons-collectie wordt al aangepast met de buttons daar, dus niet nodig op deze plaats

                cs.Wijzig(_oorspronkelijkePersoon);
            }            
        }

        private void OnTelefoonOverzichtSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _geselecteerdeTelefoon = e.AddedItems[0] as Telefoon;   
        }

        private void OnGeboorteDatumCheckBoxClick(object sender, RoutedEventArgs e)
        {
            if (GeboorteDatumCheckBox.IsChecked == false)
            {
                TeWijzigenPersoonGeboortedatumDatePicker.IsHitTestVisible = false;
                TeWijzigenPersoonGeboortedatumDatePicker.Text = string.Empty;
            }

            else if (GeboorteDatumCheckBox.IsChecked == true)
            {
                TeWijzigenPersoonGeboortedatumDatePicker.IsHitTestVisible = true;
            }

        }
    }
}
