using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Entities
{
    [Table("bedroom")]
    class Bedroom
    {
        [Key]
        public int IdBedroom { get; set; }
        public int IsAvailable { get; set; }
        public int RoomNumber { get; set; }
        public int IdTypeBedroom { get; set; }
        public int IdOptionRooms { get; set; }
        public object IdClient { get; internal set; }

        public DateTime DateClean { get; set; }

        [NotMapped]
        public string typeOfBedroom { get; set; }
    }
}
