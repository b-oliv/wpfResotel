using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjetRESOTEL.ViewModels
{
    class CleanViewModel : ViewModelBase
    {
        //l'entité du modèle
        private Bedroom bedroom;

        //Accesseur sur le modèle (Property en lecture seule)
        public Bedroom Bedroom
        {
            get { return bedroom; }
        }

        //Initialisation de la vue modèle avec l'entité modèle
        public CleanViewModel(Bedroom bedroom)
        {
            if (bedroom == null)
            {
                throw new NullReferenceException("Bedroom");
            }
            this.bedroom = bedroom;
        }

        public int RoomNumber
        {
            get { return bedroom.RoomNumber; }
            set
            {
                bedroom.RoomNumber = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime DateClean
        {
            get { return bedroom.DateClean; }
            set
            {
                bedroom.DateClean = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(Clean);
            }
        }

        private void Clean()
        {
            //ClientService.Instance.SaveClient(client);
            MessageBox.Show("Chambre " + bedroom.RoomNumber + " clean !");
            Delete();
        }

        public event EventHandler EventSupprimer;

        public void Delete()
        {
            EventSupprimer?.Invoke(this, EventArgs.Empty);
        }


    }
}
