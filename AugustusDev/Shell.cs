using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustusDev
{
    public class Shell
    {
        public UserManager UserManagmentService;
        public User CurrentUser;

        public Shell(bool requireLogin = false)
        {
            UserManagmentService = new UserManager();
            
            if (requireLogin)
            {
                User attempt = UserManagmentService.LoginUser();
                
                if (attempt.Username != "::INVALID::")
                {
                    CurrentUser = attempt;
                }
                else
                {
                    Console.WriteLine("Invalid user. Will login as guest.");
                    CurrentUser = UserManagmentService.GuestUser();
                }
            }

        }

        public void BeginLoop()
        {
            int status = 0;

            while (status == 0)
            {
                status = Cycle();
            }

            switch (status)
            {
                case 1:
                    Console.WriteLine("Shell exited at user request.");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Uncaught exit status code.");
                    Console.ReadLine();
                    break;
            }
        }

        int Cycle()
        {
            Console.Write("{0}$ ", CurrentUser.Username);
            string input = Console.ReadLine();

            if (input != "exit")
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

    }
}
