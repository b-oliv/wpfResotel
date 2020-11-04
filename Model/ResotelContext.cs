using MySql.Data.Entity;
using ProjetRESOTEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Model
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class ResotelContext : DbContext
    {
        public ResotelContext() : base()
        {
        }
        //les entités ...
        public DbSet<Client> Client { get; set; }

        public DbSet<Reservation> Reservation { get; set; }
    }
}
