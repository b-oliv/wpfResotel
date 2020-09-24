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
    class ClientViewModel : ViewModelBase
    {
        private Client client;

        //Accesseur sur le modèle (Property en lecture seule)
        public Client Client
        {
            get { return client; }
        }

        public ClientViewModel()
        {}

        //Initialisation de la vue modèle avec l'entité modèle
        public ClientViewModel(Client client)
        {
            if (client == null)
            {
                throw new NullReferenceException("Client");
            }
            this.client = client;
        }

        public string Firstname
        {
            get { return client.Firstname; }
            set
            {
                //empeche l'écrasement du nom
                if (!string.IsNullOrWhiteSpace(value))
                {
                    client.Firstname = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Lastname
        {
            get { return client.Lastname; }
            set
            {
                //empeche l'écrasement du nom
                if (!string.IsNullOrWhiteSpace(value))
                {
                    client.Lastname = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Mail
        {
            get { return client.Mail; }
            set
            {
                //empeche l'écrasement du nom
                if (!string.IsNullOrWhiteSpace(value))
                {
                    client.Mail = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Adress
        {
            get { return client.Adress; }
            set
            {
                //empeche l'écrasement du nom
                if (!string.IsNullOrWhiteSpace(value))
                {
                    client.Adress = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int Phone
        {
            get { return client.Phone; }
            set
            {
                //empeche l'écrasement du nom

                    client.Phone = value;
                    NotifyPropertyChanged();
                
            }
        }

        #region Save client

        //Commande enregistrer
        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(Save, CanSave);
            }
        }

        private void Save()
        {
            ClientService.Instance.SaveClient(client);
            MessageBox.Show("Client ajouté !");
            
        }

        private bool CanSave()
        {
            if (string.IsNullOrWhiteSpace(client.Firstname))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(client.Lastname))
            {
                return false;
            }
            return true;
        }

        #endregion

        
    }
}
