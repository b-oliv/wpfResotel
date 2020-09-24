using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Service
{
    class ClientService
    {
        #region Singleton 

        private static ClientService instance;
        public static ClientService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClientService();
                }
                return instance;
            }
        }

        private ClientService()
        {

        }

        #endregion

        public List<Client> LoadClient()
        {
            List<Client> lst = new List<Client>();

            using (ResotelContext context = new ResotelContext())
            {
                var lstClient = context.Client.ToList();
                lst.AddRange(lstClient);

            }

            return lst;

        }
    }
}
