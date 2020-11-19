using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Entities
{
    [Table("users")]
    class Users
    {
        [Key]
        public int idUsers { get; set; }
        public string uName { get; set; }
        public string uPassword { get; set; }
        public string uRole { get; set; }

    }

}
