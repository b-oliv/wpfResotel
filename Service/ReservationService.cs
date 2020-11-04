using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Service
{
    class ReservationService
    {
        #region Singleton 

        private static ReservationService _instance;
        public static ReservationService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReservationService();
                }

                return _instance;
            }
        }

        private ReservationService() { }

        #endregion

        public List<Reservation> LoadReservations()
        {
            List<Reservation> reservations = new List<Reservation>();

            using (ResotelContext context = new ResotelContext())
            {
                reservations.AddRange(context.Reservation.ToList());
            }

            return reservations;
        }
    }
}
