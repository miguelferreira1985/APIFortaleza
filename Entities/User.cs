using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserRoles { get; set; }
        public bool IsActivate { get; set; }

        public User()
        {

        }

        public User(int userId, string userName, string userPassword, string userRoles, bool isActivate)
        {
            this.UserID = userId;
            this.UserName = userName;
            this.UserPassword = userPassword;
            this.UserRoles = userRoles;
            this.IsActivate = isActivate;
        }
    }
}
