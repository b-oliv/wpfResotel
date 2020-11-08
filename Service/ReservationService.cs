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

        public string TypeOfRoom(int idBedroom)
        {

            String typeOfRoom = "NA";

            using (ResotelContext context = new ResotelContext())
            {
                var query = (from bedroom in context.Bedroom
                             join type in context.Typebedroom on bedroom.IdTypeBedroom equals type.IdTypeBedroom
                             where bedroom.IdBedroom == idBedroom
                             select type).First();

                typeOfRoom = query.Name;
            }

            return typeOfRoom;
        }

        public string RoomNumber(int idReservation)
        {

            String roomnumber = "NA";

            using (ResotelContext context = new ResotelContext())
            {

                var query = (from reservation in context.Reservation
                             join type in context.Bedroom on reservation.IdBedroom equals type.IdBedroom
                             where reservation.IdReservation == idReservation
                             select type).First();

                roomnumber = query.RoomNumber.ToString();
            }

            return roomnumber;
        }


        public string Firstname(int idReservation)
        {

            String firstname = "NA";

            using (ResotelContext context = new ResotelContext())
            {

                var query = (from reservation in context.Reservation
                             join type in context.Client on reservation.IdClient equals type.IdClient
                             where reservation.IdReservation == idReservation
                             select type).First();

                firstname = query.Firstname;
            }

            return firstname;
        }

        public string Lastname(int idReservation)
        {

            String lastname = "NA";

            using (ResotelContext context = new ResotelContext())
            {

                var query = (from reservation in context.Reservation
                             join type in context.Client on reservation.IdClient equals type.IdClient
                             where reservation.IdReservation == idReservation
                             select type).First();

                lastname = query.Lastname;
            }

            return lastname;
        }

    }
}
