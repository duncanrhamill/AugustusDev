using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustusDev
{
    public class Shell
    {
        public Shell()
        {

        }

        public void BeginLoop()
        {
            int status = 0;

            while (status == 0)
            {
                status = Cycle();
            }
        }

        int Cycle()
        {
            Console.WriteLine("$");
            Console.ReadLine();
            return 0;
        }

    }
}
