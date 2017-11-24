using ContactManager.AdoConnected;
using ContactManager.Business;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Contact geselecteerdeContact { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            IContactStore store = new ContactStore();
            var contacten = store.Contacten(ZoekWaardeTextBox.Text).OrderBy(c => c.Naam).ToList();

            Title = $"Er zijn {contacten.Count} contact(en) geladen ";
            DataOverzicht.ItemsSource = contacten;
        }

        //public bool IsContactPersoon(Persoon persoon)
        //{
        //    int id = persoon.Id;
        //    bool isContact = false;
        //    var connectionString =
        //      @"Server=(localdb)\MSSQLLocalDB;" +
        //      @"AttachDbFileName=|DataDirectory|\contacten.mdf;" +
        //      @"Initial Catalog = contacten;Integrated Security=true";
        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        const string commandStringContactID = "SELECT DISTINCT Organisatie.ContactPersoon FROM Organisatie WHERE Organisatie.Contactpersoon = @ID";
        //        using (var commandContactId = new SqlCommand(commandStringContactID, connection))
        //        {
        //            commandContactId.Parameters.AddWithValue("ID", $"{persoon.Id}");
        //            connection.Open();
        //            using (var reader = commandContactId.ExecuteReader())
        //            {
        //                if (reader.HasRows) isContact = true;
        //            }
        //        }
        //    }
        //    return isContact;
        //}

        protected virtual void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Contact placeHolder = e.AddedItems[0] as Contact;

                if (placeHolder is Organisatie)
                {
                    Organisatie org = placeHolder as Organisatie;
                    geselecteerdeContact = org;
                    ExtraContactInformatie.Text = org.ContactPersoon == null ? string.Empty : $"Contactpersoon: {org.ContactPersoon.Naam}";
                }

                else if (placeHolder is Persoon)
                {
                    Persoon pers = placeHolder as Persoon;
                    geselecteerdeContact = pers;
                    //dirty
                    ExtraContactInformatie.Text = pers.GeboorteDatum == null ? string.Empty : $"Geboortedatum: {pers}";
                }

                //toont hij hier nummer van vorige nog?
                TelefoonOverzichtListView.Items.Clear();
                foreach (Telefoon tel in geselecteerdeContact.Telefoons)
                {
                    TelefoonOverzichtListView.Items.Add(tel);
                }
            }
        }

        private void OnFilterChanged(object sender, TextChangedEventArgs e)
        {
            IContactStore store = new ContactStore();
            var contacten = store.Contacten(ZoekWaardeTextBox.Text).OrderBy(c => c.Naam).ToList();
            Title = $"Er zijn {contacten.Count} contact(en) geladen";
            DataOverzicht.ItemsSource = contacten;
        }

        private void OnNieuwContactClick(object sender, RoutedEventArgs e)
        {
            var nieuwContactVenster = new NieuwContact();
            nieuwContactVenster.ShowDialog();
        }

        private void OnWijzigContactClick(object sender, RoutedEventArgs e)
        {
            if (geselecteerdeContact.GetType() == typeof(Persoon))
            {
                var wijzigContactVenster = new WijzigPersoon(geselecteerdeContact as Persoon);
                wijzigContactVenster.Title = $"Wijzig Persoon: {geselecteerdeContact.Naam}";
                wijzigContactVenster.ShowDialog();
            }
            else if (geselecteerdeContact.GetType() == typeof(Organisatie))
            {
                var wijzigContactVenster = new WijzigOrganisatie(geselecteerdeContact as Organisatie);
                wijzigContactVenster.Title = $"Wijzig Organisatie: {geselecteerdeContact.Naam}";
                wijzigContactVenster.ShowDialog();
            }
        }

        private void OnVerwijderContactClick(object sender, RoutedEventArgs e)
        {
            //cascade delete inbouwen
        }
    }
}



