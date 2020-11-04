using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.ViewModels
{
    class ReservationsViewModel : ViewModelBase
    {

        private List<ReservationViewModel> _reservations = new List<ReservationViewModel>();
        public List<ReservationViewModel> Reservations
        {
            get => _reservations;
            set => _reservations = value;
        }

        public ReservationsViewModel()
        {
            //charge le modèle
            List<Reservation> lst = ReservationService.Instance.LoadReservations();

            foreach (Reservation reservation in lst)
            {
                ReservationViewModel vm = new ReservationViewModel(reservation);
                _reservations.Add(vm);
            }
        }

    }
}
