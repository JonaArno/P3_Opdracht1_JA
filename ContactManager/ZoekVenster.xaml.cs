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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ContactManager.AdoConnected;
using ContactManager.Business;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for ZoekVenster.xaml
    /// </summary>
    public partial class ZoekVenster : Window
    {
        private Persoon _geselecteerdeContactPersoon = new Persoon();
        private WijzigOrganisatie _teWijzigenOrganisatieVenster;
        private NieuwContact _teWijzigenContactVenster;
        private bool _isNieuw = false;

        public ZoekVenster(WijzigOrganisatie wijzigOrgVenster)
        {
            InitializeComponent();
            IContactStore store = new ContactStore();
            var personen = store.Personen(ZoekFilterTextBox.Text).OrderBy(c => c.Naam).ToList();
            Title = $"Er zijn {personen.Count} perso(o)n(en) teruggevonden";
            ZoekResultaatOverzicht.ItemsSource = personen;

            _teWijzigenOrganisatieVenster = wijzigOrgVenster;
        }

        public ZoekVenster(NieuwContact nieuwContactVenster)
        {
            InitializeComponent();
            IContactStore store = new ContactStore();
            var personen = store.Personen(ZoekFilterTextBox.Text).OrderBy(c => c.Naam).ToList();
            Title = $"Er zijn {personen.Count} perso(o)n(en) teruggevonden";
            ZoekResultaatOverzicht.ItemsSource = personen;

            _teWijzigenContactVenster = nieuwContactVenster;
            _isNieuw = true;
        }

        //doorgeefluik naar nieuwcontact/wijzigcontact 
        private void OnZoekVensterOkClick(object sender, RoutedEventArgs e)
        {
            if (_isNieuw == false)
            {
                _teWijzigenOrganisatieVenster.ContactPersoon = _geselecteerdeContactPersoon;
                _teWijzigenOrganisatieVenster.GeselecteerdeContactTextBox.Text = _geselecteerdeContactPersoon.Naam;
            }
            else if (_isNieuw == true)
            {
                _teWijzigenContactVenster.ContactPersoon = _geselecteerdeContactPersoon;
                _teWijzigenContactVenster.NieuwContactContactPersoonTextBox.Text = _geselecteerdeContactPersoon.Naam;
            }

            this.Close();
        }

        private void OnZoekVensterCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnFilterChanged(object sender, TextChangedEventArgs e)
        {
            //niet zeker of hier nog extra naar bindings gekeken moet worden
            //in gaten houden bij testen
            IContactStore store = new ContactStore();
            var personen = store.Personen(ZoekFilterTextBox.Text).OrderBy(c => c.Naam).ToList();
            Title = $"Er zijn {personen.Count} perso(o)n(en) teruggevonden";
            ZoekResultaatOverzicht.ItemsSource = personen;
        }

        private void OnZoekVensterSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                _geselecteerdeContactPersoon = e.AddedItems[0] as Persoon;
            }
        }
    }
}
