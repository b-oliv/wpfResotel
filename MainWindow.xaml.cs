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
        }

        private void OnNewClientButtonClick(object sender, RoutedEventArgs e)
        {
            NavigateToNewClientWindow();
        }

        private void OnEditClientButtonClick(object sender, RoutedEventArgs e)
        {
            NavigateToEditClientWindow();
        }

        private void OnNewReservationButtonClick(object sender, RoutedEventArgs e)
        {
            NavigateToNewReservationWindow();
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

        private void NavigateToNewClientWindow()
        {
            Display(new ucNewClient());
        }

        private void NavigateToEditClientWindow()
        {
            Display(new ucEditClient());
        }

        private void NavigateToNewReservationWindow()
        {
            Display(new ucNewReservation());
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
