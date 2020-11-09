﻿using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

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
            ReservationService.Instance.SaveReservation(ReservationSelected.Reservation);
            MessageBox.Show("Reservation enregistrée !");
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
            if (ReservationService.Instance.DeleteReservation(ReservationSelected.Reservation))
            {
                EventSupprimer?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Reservation supprimé !");
            }
        }

        #endregion

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
