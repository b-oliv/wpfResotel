using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Entities
{
    //Data Transfert Object for bedrooms / client / reservation
    class ItemReservation
    {
        public ItemReservation(Bedroom room)
        {
            bedroom = room;
        }

        [NotMapped]
        public Bedroom bedroom { get; set; }

        [NotMapped]
        public Client client { get; set; }

        [NotMapped]
        public Reservation reservation { get; set; }

    }
}
