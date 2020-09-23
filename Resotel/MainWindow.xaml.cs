using Resotel.Views;
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

namespace Resotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NavToHome(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nav to home");
            _mainFrame.Navigate(new Home());
        }

        private void NavToClient(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nav to Client");
            Page page1 = new Client();
            _mainFrame.Navigate(page1);
        }
    }
}
