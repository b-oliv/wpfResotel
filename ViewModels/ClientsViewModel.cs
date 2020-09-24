using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace ProjetRESOTEL.ViewModels
{
    class ClientsViewModel : ViewModelBase
    {
        public ObservableCollection<ClientViewModel> Clients { get => _clients; }
        public ClientViewModel ContactSelected { get => _observer.CurrentItem as ClientViewModel; }

        private readonly ObservableCollection<ClientViewModel> _clients;
        private readonly ICollectionView _observer;

        public ClientsViewModel()
        {
            List<Client> clients = ClientService.Instance.LoadClients();

            _clients = new ObservableCollection<ClientViewModel>();

            foreach (Client person in clients)
            {
                _clients.Add(new ClientViewModel(person));
            }

            _observer = CollectionViewSource.GetDefaultView(_clients);
            _observer.CurrentChanged += OnSelectedClientChanged;
            _observer.MoveCurrentToLast();
        }

        private void OnSelectedClientChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("ClientSelected");
        }
    }
}
