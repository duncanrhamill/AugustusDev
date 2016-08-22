using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace AugustusDev
{
    public class User
    {
        public string Username;
        private string Password;

        public User()
        {
            Username = "";
            Password = "";
        }

        public User(string name, string pass)
        {
            Username = name;
            Password = pass;
        }

        public bool Authenticate(string passAttempt)
        {
            return passAttempt == Password;
        }

        public bool Authenticate(System.Security.SecureString passAttempt)
        {
            IntPtr unmanagedString = IntPtr.Zero;

            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(passAttempt);
                return (Marshal.PtrToStringUni(unmanagedString) == Password);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
