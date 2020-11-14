﻿using MaterialDesignThemes.Wpf;
using ProjetRESOTEL.ViewModels;
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

namespace ProjetRESOTEL.Views
{
    /// <summary>
    /// Logique d'interaction pour ucDialog.xaml
    /// </summary>
    public partial class ucDialog : UserControl
    {
        public ucDialog()
        {
            InitializeComponent();
        }

        private void Button_Click_Reserve(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Réservation Enregistrée !!");
            // Ici tratement et envoie des data au service pour persistence des data en base
        }
    }
}
