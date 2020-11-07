using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Model;
using System;
using System.Collections.Generic;
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

    }
}
