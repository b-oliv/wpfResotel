using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Service
{
    class BedroomService
    {

        #region Singleton 

        private static BedroomService _instance;
        public static BedroomService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BedroomService();
                }

                return _instance;
            }
        }

        private BedroomService() { }

        #endregion

        public List<Bedroom> LoadBedrooms()
        {
            List<Bedroom> bedrooms = new List<Bedroom>();

            using (ResotelContext context = new ResotelContext())
            {
                bedrooms.AddRange(context.Bedroom.ToList());
            }

            return bedrooms;
        }

        public List<Bedroom> LoadNoCleanBedrooms()
        {
            List<Bedroom> bedrooms = new List<Bedroom>();
            DateTime date = DateTime.Now.AddDays(-1);

            using (ResotelContext context = new ResotelContext())
            {
                var query = (from bedroom in context.Bedroom
                             where bedroom.DateClean <= date
                             select bedroom).ToList<Bedroom>();

                bedrooms = query;
            }

            return bedrooms;
        }

        public bool UpdateCleanBedroom(Bedroom bedroom)
        {
            bedroom.DateClean = DateTime.Now;
            using (ResotelContext context = new ResotelContext())
            {
                if (bedroom.IdBedroom > 0)
                {
                    //on l'attache au contexte pour la mettre à jour
                    context.Bedroom.Attach(bedroom);
                    //et on met son statut à modifié
                    context.Entry(bedroom).State = EntityState.Modified;
                }
                //répercute les changements en base
                context.SaveChanges();
            }
            return true;
        }


        public string TypeOfRoom(int idBedroom)
        {

            String typeOfRoom = "NA";

            using (ResotelContext context = new ResotelContext())
            {
                var query = (from bedroom in context.Bedroom
                             join type in context.Typebedroom on bedroom.IdTypeBedroom equals type.IdTypeBedroom
                             where bedroom.IdBedroom == idBedroom
                             select type).First();

                typeOfRoom = query.Name;
            }

            return typeOfRoom;
        }

    }
}
