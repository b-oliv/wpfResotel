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

        private void Vm_EventSupprimer(object sender, EventArgs e)
        {
            _clients.Remove(sender as ClientViewModel);
            NotifyPropertyChanged("Clients");
        }

        private void OnSelectedClientChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("ClientSelected");
        }

        public ClientViewModel ClientSelected
        {
            get
            {
                return _observer.CurrentItem as ClientViewModel;
            }
        }

        #region Edit
        //Commande enregistrer
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
            MessageBox.Show("Client modifié !");
        }

        #endregion

        #region Supprimer

        //event de supression pour alerte la view modele parente
        public event EventHandler EventSupprimer;

        //Commande Supprimer
        public ICommand DeleteCommand
        {
            get
            {
                //Comment supprimer cet élément ContactViewModel de la liste ListeContacts qui est dans ListeContactViewModels ?
                return new RelayCommand(Delete);
            }
        }

        private void Delete()
        {
            if (ClientService.Instance.DeleteClient(ClientSelected.Client))
            {
                EventSupprimer?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Client supprimé !");
            }
        }

        #endregion
    }
}
