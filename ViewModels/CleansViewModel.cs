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
    class CleansViewModel : ViewModelBase
    {
        public ObservableCollection<CleanViewModel> Bedrooms { get => _bedrooms; }

        private readonly ObservableCollection<CleanViewModel> _bedrooms;
        private readonly ICollectionView _observer;

        public CleansViewModel()
        {
            List<Bedroom> bedrooms = BedroomService.Instance.LoadNoCleanBedrooms();

            _bedrooms = new ObservableCollection<CleanViewModel>();

            foreach (Bedroom chamber in bedrooms)
            {
                CleanViewModel vm = new CleanViewModel(chamber);
                vm.EventSupprimer += Vm_EventSupprimer;
                _bedrooms.Add(vm);
            }

            _observer = CollectionViewSource.GetDefaultView(_bedrooms);
            _observer.CurrentChanged += OnSelectedClientChanged;
            _observer.MoveCurrentToLast();
        }

        private void Vm_EventSupprimer(object sender, EventArgs e)
        {
            BedroomService.Instance.UpdateCleanBedroom(BedroomSelected.Bedroom);
            _bedrooms.Remove(BedroomSelected as CleanViewModel);
            NotifyPropertyChanged("Bedrooms");
        }

        private void OnSelectedClientChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("BedroomSelected");
        }

        public CleanViewModel BedroomSelected
        {
            get
            {
                return _observer.CurrentItem as CleanViewModel;
            }
        }
    }
}
