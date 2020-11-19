using ProjetRESOTEL.ViewModels;
using ProjetRESOTEL.Views;
using System.Windows;
using System.Windows.Controls;

namespace ProjetRESOTEL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        //l'entité du modèle
        private readonly string _role;
        

        public MainWindow()
        {
            this._role = (string)Application.Current.Properties["role"];
            InitializeComponent();
            DefineHomePage();
            CheckRole();
        }

        private void DefineHomePage()
        {
            if (this._role == "Admin")
            {
                MainTab.Items.Add(new TabItem { Content = new ucHome() });
            }
            else
            {
                 _ = _role.Equals("Food") ? MainTab.Items.Add(new TabItem { Content = new ucCheckFood() }) : MainTab.Items.Add(new TabItem { Content = new ucCleanChamber() });
            }
        }

        private void CheckRole()
        {
            if (!_role.Equals("Admin"))
            {
                Menu control = menu as Menu;
                foreach (MenuItem item in control.Items)
                {
                    item.IsEnabled = false;
                }

                if (_role.Equals("Food"))
                {
                    MenuItem item = CheckFoodButton as MenuItem;
                    item.IsEnabled = true;
                }

                if (_role.Equals("Clean"))
                {
                    MenuItem item = CheckCleanChamber as MenuItem;
                    item.IsEnabled = true;
                }
            }
        }

        private void OnHomeButtonClick(object sender, RoutedEventArgs e)
        {
            NavigateToHomeWindow();
        }
        
        private void OnNewClientButtonClick(object sender, RoutedEventArgs e)
        {
            NavigateToNewClientWindow();
        }

        private void OnEditClientButtonClick(object sender, RoutedEventArgs e)
        {
            NavigateToEditClientWindow();
        }

        private void OnReservationListButtonClick(object sender, RoutedEventArgs e)
        {
            NavigateToReservationListWindow();
        }

        private void OnCheckFoodButtonClick(object sender, RoutedEventArgs e)
        {
            NavigateToCheckFoodWindow();
        }

        private void OnCheckCleanChamber(object sender, RoutedEventArgs e)
        {
            NavigateToCheckCleanChamberWindow();
        }

        private void btnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vous êtes bien déconnecté !");
            ucConnexion window = new ucConnexion();
            window.Show();
            this.Close();
        }

        private void Display(UserControl userControl)
        {
            MainTab.Items.Clear();
            MainTab.Items.Add(new TabItem { Content = userControl });
            MainTab.Items.Refresh();
        }

        private void NavigateToHomeWindow()
        {
            Display(new ucHome());
        }

        private void NavigateToNewClientWindow()
        {
            Display(new ucNewClient());
        }

        private void NavigateToEditClientWindow()
        {
            Display(new ucEditClient());
            this.DataContext = new ClientsViewModel().ClientSelected;
        }

        private void NavigateToReservationListWindow()
        {
            Display(new ucListReservation());
        }

        private void NavigateToCheckFoodWindow()
        {
            Display(new ucCheckFood());
        }

        private void NavigateToCheckCleanChamberWindow()
        {
            Display(new ucCleanChamber());
        }
    }
}
