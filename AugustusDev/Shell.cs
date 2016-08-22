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

        public Shell()
        {
            UserManagmentService = new UserManager();
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
            Console.Write("$");
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
