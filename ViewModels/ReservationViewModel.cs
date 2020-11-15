using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.ViewModels
{
    class ReservationViewModel : ViewModelBase
    {
        //l'entité du modèle
        private readonly Reservation _reservation;

        //Accesseur sur le modèle (Property en lecture seule)
        public Reservation Reservation
        {

            get { return _reservation; }
        }

        public ReservationViewModel()
        { }

        //Initialisation de la vue modèle avec l'entité modèle
        public ReservationViewModel(Reservation reservation)
        {
            this._reservation = reservation ?? throw new NullReferenceException("Reservation");
        }

        public string Name
        {
            get { return _reservation.Name; }
            set
            {
                //empeche l'écrasement du nom
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _reservation.Name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int IdReservation
        {
            get { return _reservation.IdReservation; }
            set
            {
                  _reservation.IdReservation = value;
                  NotifyPropertyChanged();
            }
        }

        public DateTime StartDate
        {
            get { return _reservation.StartDate; }
            set
            {
                 _reservation.StartDate = value;
                 NotifyPropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get { return _reservation.EndDate; }
            set
            {
                _reservation.EndDate = value;
                NotifyPropertyChanged();
            }
        }

        public string TypeBedroom
        {
            get { return ReservationService.Instance.TypeOfRoom(_reservation.IdBedroom); }
        }

        public string RoomNumber
        {
            get { return ReservationService.Instance.RoomNumber(_reservation.IdReservation); }
        }

        public string Firstname
        {
            get { return ReservationService.Instance.Firstname(_reservation.IdReservation); }
        }

        public string Lastname
        {
            get { return ReservationService.Instance.Lastname(_reservation.IdReservation); }
        }

    }
}
