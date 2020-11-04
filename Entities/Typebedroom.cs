using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Entities
{
    [Table("typebedroom")]
    class Typebedroom
    {
        [Key]
        public int IdTypeBedroom { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Capacity { get; set; }
        public int HasBaby { get; set; }
    }
}
