using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Service
{
    class UserService
    {

        #region Singleton 

        private static UserService _instance;
        public static UserService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserService();
                }

                return _instance;
            }
        }

        private UserService() { }

        #endregion


        public Users GetUser(string uName, string uPassword)
        {

            Users GetUser = new Users();

            using (ResotelContext context = new ResotelContext())
            {
                var query = (from users in context.Users
                             where users.uName == uName
                             where users.uPassword == uPassword
                             select users).FirstOrDefault();

                GetUser = query;
                Console.WriteLine();
            }

            return GetUser;
        }

    }
}
