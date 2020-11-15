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
        private readonly Client client;

        //Accesseur sur le modèle (Property en lecture seule)
        public Client Client => client;

        //Initialisation de la vue modèle avec l'entité modèle
        public ClientViewModel(Client client)
        {
            this.client = client ?? throw new NullReferenceException("Client");
        }

        public string Firstname
        {
            get { return client.Firstname; }
            set
            {
                //empeche l'écrasement de la valeur
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
                    client.Phone = value;
                    NotifyPropertyChanged();
            }
        }

        #region Delete client
        public event EventHandler EventSupprimer;

        public void Delete()
        {
            EventSupprimer?.Invoke(this, EventArgs.Empty);
        }
        #endregion


        #region Save client

        //Commande to add client - command to xaml newClient
        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(Save, CanSave);
            }
        }

        private void Save()
        {
            ClientService.Instance.SaveClient(client);
            MessageBox.Show("Client " + client.Lastname + " " +  client.Lastname + " ajouté !");
        }

        //Check if this property is reachable for command relay
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
