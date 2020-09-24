using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public bool SaveClient(Client client)
        {
            using (ResotelContext context = new ResotelContext())
            {
                if (client.IdClient > 0)
                {
                    //le client existe, on l'attache au contexte pour le mettre à jour
                    context.Client.Attach(client);
                    //et on met son statut à modifié
                    context.Entry(client).State = EntityState.Modified;
                }
                else
                {
                    //le client est nouveau, on l'ajoute à la liste
                    context.Client.Add(client);
                }
                //répercute les changements en base
                context.SaveChanges();
            }
            return true;
        }

        public bool DeleteClient(Client client)
        {
            try
            {
                using (ResotelContext context = new ResotelContext())
                {
                    context.Client.Attach(client as Client);
                    context.Client.Remove(client as Client);
                    context.SaveChanges();
                }
                return true;

            }
            catch (Exception)
            {
                //todo gestion erreurs

            }
            return false;
        }
    }
}
