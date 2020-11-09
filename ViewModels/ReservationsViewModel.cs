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
        public ObservableCollection<ReservationViewModel> Reservations { get => _reservations; }

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
            _observer.CurrentChanged += OnSelectedClientChanged;
            _observer.MoveCurrentToLast();
        }

        private void OnSelectedClientChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("ReservationSelected");
        }

        public ReservationViewModel ReservationSelected
        {
            get
            {
                return _observer.CurrentItem as ReservationViewModel;
            }
        }

        #region Recherche textuelle

        //Propriété récupérant le texte de recherche saisi
        public string TexteRechercher
        {
            set
            {
                _observer.Filter = item => IsMatch(item, value);
                NotifyPropertyChanged("TexteRechercherNoMatch");
            }
        }

        //Pour le setter : si la recherche est vide, on applique un style différent
        public bool TexteRechercherNoMatch
        {
            get { return _observer.IsEmpty; }
        }

        // Méthode appellée pour chaque élément de la collection
        // pour déterminer si l'élément correspond ou non à la recherche.
        private bool IsMatch(object item, string value)
        {
            if (!(item is ReservationViewModel)) return false;

            value = value.ToUpper();
            ReservationViewModel p = (ReservationViewModel)item;
            return (p.Reservation.Name.ToUpper().Contains(value)
                    || p.Reservation.Name.ToUpper().Contains(value));
        }

        #endregion


    }
}
