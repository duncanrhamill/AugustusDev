using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustusDev
{
    public class Kernel
    {
        public readonly string VersionNumber = "0.0.1";

        static void Main(string[] args)
        {
            Kernel kern = new Kernel();
            kern.BeforeRun();
            kern.Run();
        }

        public void BeforeRun()
        {
            Console.WriteLine("Augustus\nVersion {0}", VersionNumber);
        }

        public void Run()
        {
            Console.ReadLine();
        }
    }
}
