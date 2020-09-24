using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ProjetRESOTEL.ViewModels
{
    class ListeClientViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ClientViewModel> listeClient;
        public ObservableCollection<ClientViewModel> ListeClient
        {
            get
            {
                return listeClient;
            }
        }


        //observateur de la liste observable
        private readonly ICollectionView observer;

        public ListeClientViewModel()
        {
            //charge le modèle
            List<Client> lst = ClientService.Instance.LoadClient();

            //créé la liste des viewsmodeles pour chaque entité
            listeClient = new ObservableCollection<ClientViewModel>();
            foreach (Client person in lst)
            {
                ClientViewModel vm = new ClientViewModel(person);
                //vm.EventSupprimer += Vm_EventSupprimer;
                listeClient.Add(vm);
            }

            //lier l'observer à la liste
            observer = CollectionViewSource.GetDefaultView(listeClient);

            //ajoute l'événement qui notifie que la sélection a changer dans la vue
            observer.CurrentChanged += Observer_CurrentChanged;

            observer.MoveCurrentToLast();

        }

        private void Observer_CurrentChanged(object sender, EventArgs e)
        {
            //avertir la/les vues qui utilise la propriété ContactSelected de faire un refresh (get)
            NotifyPropertyChanged("ClientSelected");
        }

        public ClientViewModel ContactSelected
        {
            get
            {
                return observer.CurrentItem as ClientViewModel;
            }
        }

    }
}
