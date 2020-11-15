using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        #endregion

        private ReservationService() { }

        public bool SaveReservation(Reservation reservation)
        {
            using (ResotelContext context = new ResotelContext())
            {
                if (reservation.IdReservation > 0)
                {
                    //la réervation existe, on l'attache au contexte pour la mettre à jour
                    context.Reservation.Attach(reservation);
                    //et on met son statut à modifié
                    context.Entry(reservation).State = EntityState.Modified;
                }
                else
                {
                    //le client est nouveau, on l'ajoute à la liste
                    context.Reservation.Add(reservation);
                }
                //répercute les changements en base
                context.SaveChanges();
            }
            return true;
        }

        internal bool DeleteReservation(Reservation reservation)
        {
            using (ResotelContext context = new ResotelContext())
            {
                if (reservation.IdReservation > 0)
                {
                    //la réervation existe, on l'attache au contexte pour la mettre à jour
                    context.Reservation.Attach(reservation);
                    //et on met son statut à modifié
                    context.Entry(reservation).State = EntityState.Deleted;
                }
                //répercute les changements en base
                context.SaveChanges();
            }
            return true;
        }

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
 
            String roomnumber = "☻";

            using (ResotelContext context = new ResotelContext())
            {
                var query = (from reservation in context.Reservation
                             join bedroom in context.Bedroom on reservation.IdBedroom equals bedroom.IdBedroom
                             where reservation.IdReservation == idReservation
                             select bedroom).First();
                if (query != null)
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
