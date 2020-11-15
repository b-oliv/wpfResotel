using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace ProjetRESOTEL.ViewModels
{
    class ClientsViewModel : ViewModelBase
    {
        public ObservableCollection<ClientViewModel> Clients { get => _clients; }

        private readonly ObservableCollection<ClientViewModel> _clients;
        private readonly ICollectionView _observer;

        // Step 1 - Get data from service and linked to eventHandler
        // step 2 - Define client selected(observervable collection)
        public ClientsViewModel()
        {
            List<Client> clients = ClientService.Instance.LoadClients();

            _clients = new ObservableCollection<ClientViewModel>();

            foreach (Client person in clients)
            {
                ClientViewModel vm = new ClientViewModel(person);
                vm.EventSupprimer += Vm_EventSupprimer;
                _clients.Add(vm);
            }

            _observer = CollectionViewSource.GetDefaultView(_clients);
            _observer.CurrentChanged += OnSelectedClientChanged;
            _observer.MoveCurrentToLast();
        }

        // event linked to each clientViewModel
        private void Vm_EventSupprimer(object sender, EventArgs e)
        {
            ClientService.Instance.DeleteClient(ClientSelected.Client);
            MessageBox.Show("Client " + ClientSelected.Client.Lastname + " " + ClientSelected.Client.Firstname + "  supprimé !");
            _clients.Remove(ClientSelected as ClientViewModel);
            NotifyPropertyChanged("Clients");
        }

        // Notification of Property change - interface InotifyPropertyChange - Send new data to view
        private void OnSelectedClientChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("ClientSelected");
        }

        // Return the client selected in list
        public ClientViewModel ClientSelected
        {
            get
            {
                return _observer.CurrentItem as ClientViewModel;
            }
        }

        // Command interface (link to xaml) use RelayCommand for EventClick
        #region Edit
        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(Edit);
            }
        }

        private void Edit()
        {
            ClientService.Instance.SaveClient(ClientSelected.Client);
            MessageBox.Show("Client " + ClientSelected.Client.Lastname + " " + ClientSelected.Client.Firstname + "  modifié !");
        }

        #endregion

        #region Delete
        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(ClientSelected.Delete);
            }
        }
        #endregion
    }
}
