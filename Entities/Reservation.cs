using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Entities
{
    [Table("reservation")]
    class Reservation
    {
        [Key]
        public int IdReservation { get; set; }

        [StringLength(45)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }


        public int AmountPaiement { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DatePaiement { get; set; }


        public int IdOption { get; set; }
        public int IdBedroom { get; set; }
        public int IdClient { get; set; }


        public override string ToString()
        {
            return $"Reservation: {IdReservation} - {Name}";
        }
    }
}
