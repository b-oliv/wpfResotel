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
        public MainWindow()
        {
            InitializeComponent();
            MainTab.Items.Add(new TabItem { Content = new ucHome() });
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
    }
}
