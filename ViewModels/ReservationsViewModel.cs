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
    class ReservationsViewModel : ViewModelBase
    {
        public ObservableCollection<ReservationViewModel> Clients { get => _reservations; }

        private readonly ObservableCollection<ReservationViewModel> _reservations;
        private readonly ICollectionView _observer;

        public ReservationsViewModel()
        {
            //charge le modèle
            List<Reservation> lst = ReservationService.Instance.LoadReservations();

            _reservations = new ObservableCollection<ReservationViewModel>();

            foreach (Reservation reservation in lst)
            {
                ReservationViewModel vm = new ReservationViewModel(reservation);
                _reservations.Add(vm);
            }

            _observer = CollectionViewSource.GetDefaultView(_reservations);
        }

        public ReservationViewModel ReservationSelected
        {
            get
            {
                return _observer.CurrentItem as ReservationViewModel;
            }
        }


    }
}
