using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Service;
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
using TextBox = System.Windows.Controls.TextBox;

namespace ProjetRESOTEL.Views
{

    public partial class ucConnexion : Window
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ucConnexion()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            TextBox usernameText = userText as TextBox;
            PasswordBox passwordText = passText as PasswordBox;

            Users users = UserService.Instance.GetUser(usernameText.Text, passwordText.Password);

            if (users != null)
            {
                
                Application.Current.Properties["role"] = users.uRole;
                log.Info("L'utilisateur connecté " + users.uName);
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Login ou Mot de passe incorrect!");
                log.Error("Erreur de connexion");
            }

        }
    }
}
