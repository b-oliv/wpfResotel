using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetRESOTEL.Views
{

    public partial class ucConnexion : Window
    {
        public ucConnexion()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vous êtes bien connecté !");
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }





    }
}
