using ProjetRESOTEL.Views;
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

namespace ProjetRESOTEL
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Redirection vers Création d'un Client
        private void OnNewClientButtonClick(object sender, RoutedEventArgs e)
        {
            NavigateToNewClientWindow();
        }

        private void NavigateToNewClientWindow()
        {
            TabItem _tabUserPage;
            MainTab.Items.Clear(); //Clear previous Items in the user controls which is my tabItems    
            var userControls = new ucNewClient();
            _tabUserPage = new TabItem { Content = userControls };
            MainTab.Items.Add(_tabUserPage); // Add User Controls    
            MainTab.Items.Refresh();
        }

        // Redirection vers Création d'un Client
        private void btnEditClient_Click(object sender, RoutedEventArgs e)
        {
            TabItem _tabUserPage;
            MainTab.Items.Clear(); //Clear previous Items in the user controls which is my tabItems    
            var userControls = new ucEditClient();
            _tabUserPage = new TabItem { Content = userControls };
            MainTab.Items.Add(_tabUserPage); // Add User Controls    
            MainTab.Items.Refresh();
        }

        // Redirection vers Création Réservation
        private void btnNewReservation_Click(object sender, RoutedEventArgs e)
        {
            TabItem _tabUserPage;
            MainTab.Items.Clear(); //Clear previous Items in the user controls which is my tabItems    
            var userControls = new ucNewReservation();
            _tabUserPage = new TabItem { Content = userControls };
            MainTab.Items.Add(_tabUserPage); // Add User Controls    
            MainTab.Items.Refresh();
        }

        // Redirection vers Liste Réservation
        private void btnListReservation_Click(object sender, RoutedEventArgs e)
        {
            TabItem _tabUserPage;
            MainTab.Items.Clear(); //Clear previous Items in the user controls which is my tabItems    
            var userControls = new ucListReservation();
            _tabUserPage = new TabItem { Content = userControls };
            MainTab.Items.Add(_tabUserPage); // Add User Controls    
            MainTab.Items.Refresh();
        }

    }
}
