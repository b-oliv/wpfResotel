using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Model;
using System.Collections.Generic;
using System.Linq;

namespace ProjetRESOTEL.Service
{
    class ClientService
    {
        #region Singleton 

        private static ClientService _instance;

        public static ClientService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClientService();
                }

                return _instance;
            }
        }

        private ClientService() { }

        #endregion

        public List<Client> LoadClients()
        {
            List<Client> clients = new List<Client>();

            using (ResotelContext context = new ResotelContext())
            {
                clients.AddRange(context.Client.ToList());
            }

            return clients;
        }
    }
}
