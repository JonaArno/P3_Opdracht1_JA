using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for NieuwContact.xaml
    /// </summary>
    public partial class NieuwContact : Window
    {
        private List<Telefoon> telLijst = new List<Telefoon>();
        public Persoon ContactPersoon { get; set; }
        
        public NieuwContact()
        {
            InitializeComponent();
        }

        //controle toevoegen voor als velden niet ingevoerd zijn !!! TO DO
        private void OnContactAanmakenButtonClicked(object sender, RoutedEventArgs e)
        {
            ContactStore c = new ContactStore();

            bool isOrganisatie;
            if (ContactIsOrganisatieCheckBox.IsChecked == true) isOrganisatie = true; else isOrganisatie = false;


            //herhaalde logica in aparte method steken voor Organisatie + Persoon
            if (isOrganisatie)
            {
                Organisatie org = new Organisatie();
                org.Naam = NieuwContactNaamTextBox.Text;
                org.Adres.Straat = NieuwContactStraatTextBox.Text;
                org.Adres.Locatie = NieuwContactLocatieTextBox.Text;
                org.Adres.Land = NieuwContactLandTextBox.Text;

                //Hier moet nog gekeken worden hoe op basis van een naam een persoon object toe te voegen
                if (OrganisatieHeeftContactPersoonCheckBox.IsChecked == true)
                {
                    //org.ContactPersoon = NieuwContactContactPersoonTextBox.Text;
                }
                //beste manier?
                c.Nieuw(org);
            }
            else
            {
                Persoon pers = new Persoon();
                pers.Naam = NieuwContactNaamTextBox.Text;
                pers.Adres.Straat = NieuwContactStraatTextBox.Text;
                pers.Adres.Locatie = NieuwContactLocatieTextBox.Text;
                pers.Adres.Land = NieuwContactLandTextBox.Text;

                if (NieuwContactBirthdatePicker != null)
                {
                    pers.GeboorteDatum = DateTime.Parse(NieuwContactBirthdatePicker.Text);
                }
                c.Nieuw(pers);
            }
        }

        private void OnNieuwContactCancelClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnTelefoonInformatieToevoegenButtonClick(object sender, RoutedEventArgs e)
        {
            var tel = new Telefoon();
            tel.TelefoonType = TelefoonNaamToevoegenTextBox.Text;
            tel.Nummer = TelefoonNummerToevoegenTextBox.Text;

            telLijst.Add(tel);
            //was nodig om lijst te kunnen refreshen, anders zie ik enkel eerst toegevoegde item
            TelefoonOverzichtListView.ItemsSource = null;
            TelefoonOverzichtListView.ItemsSource = telLijst;

            TelefoonNaamToevoegenTextBox.Clear();
            TelefoonNummerToevoegenTextBox.Clear();
        }

        private void KiesContactPersoonButton_Click(object sender, RoutedEventArgs e)
        {
            var zoekVenster = new ZoekVenster(this);
            zoekVenster.ShowDialog();
        }
    }
}
