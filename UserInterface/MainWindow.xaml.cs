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
using ContactManager.Business;
using ContactManager.AdoConnected;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IContactStore store = new ContactStore();
            var contacten = store.Contacten($"{ZoekWaarde.Text}").OrderBy(c => c.Naam).ToList();

            Title = $"Er zijn {contacten.Count} contact(en) geladen ";
            DataOverzicht.ItemsSource = contacten;

        }
    }
}
