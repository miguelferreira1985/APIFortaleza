using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace Repository
{
    public class UserRepository
    {
        DALUser dalUser;

        public User validateUser(string userName, string userPassword)
        {
            User user = new User()
            {
                UserName = userName,
                UserPassword = userPassword
            };

            dalUser = new DALUser();

            var validateUser = dalUser.dalValidateUser(user);

            return validateUser;
        }
    }
}
