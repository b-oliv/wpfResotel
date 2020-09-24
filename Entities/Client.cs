using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Entities
{
    class Client
    {
        public int IdClient { get; set; }
        [StringLength(80)]

        public string Firstname { get; set; }
        [StringLength(80)]

        public string Lastname { get; set; }
        [StringLength(80)]

        public int Phone { get; set; }
        [StringLength(80)]

        public string Mail { get; set; }
        [StringLength(80)]

        public string Adress { get; set; }


        public override string ToString()
        {
            return $"Client {Firstname} {Lastname}";
        }
    }
}
