using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustusDev
{
    public class UserManager
    {
        public List<User> Users;

        public UserManager()
        {
            Users = new List<User>();
            Users.Add(new User("root", "pass"));
        }
    }
}
