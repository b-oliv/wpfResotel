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
    class BedroomsViewModel : ViewModelBase
    {
        public ObservableCollection<BedroomViewModel> Bedrooms { get => _bedrooms; }

        private readonly ObservableCollection<BedroomViewModel> _bedrooms;
        private readonly ICollectionView _observer;

        public BedroomsViewModel()
        {
            List<Bedroom> bedrooms = BedroomService.Instance.LoadBedrooms();

            _bedrooms = new ObservableCollection<BedroomViewModel>();

            foreach (Bedroom chamber in bedrooms)
            {
                BedroomViewModel vm = new BedroomViewModel(chamber);
                _bedrooms.Add(vm);
            }

            _observer = CollectionViewSource.GetDefaultView(_bedrooms);
            _observer.CurrentChanged += OnSelectedClientChanged;
            _observer.MoveCurrentToLast();
        }

        private void Vm_EventSupprimer(object sender, EventArgs e)
        {
            _bedrooms.Remove(sender as BedroomViewModel);
            NotifyPropertyChanged("Chambre");
        }

        private void OnSelectedClientChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("ChambreSelectionné");
        }

        public BedroomViewModel BedroomSelected
        {
            get
            {
                return _observer.CurrentItem as BedroomViewModel;
            }
        }
    }
}
