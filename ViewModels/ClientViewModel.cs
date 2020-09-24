using ProjetRESOTEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
