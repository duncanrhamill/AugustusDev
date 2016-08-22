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
            Users.Add(new User("guest", "guest"));
        }

        public User GetUserByName(string username)
        {
            return Users.First(u => u.Username == username);
        }

        public User GuestUser()
        {
            return Users.First(u => u.Username == "guest");
        }

        public bool UserExists(string username)
        {
            return Users.Where(u => u.Username == username).Count() > 0;
        }

        public User LoginUser()
        {
            User usr = new User();

            Console.WriteLine("Process requires user to login.");

            bool success = false;

            while (!success)
            {
                bool userFound = false;

                while (!userFound)
                {
                    Console.Write("username: ");
                    string name = Console.ReadLine();

                    if (UserExists(name))
                    {
                        usr = GetUserByName(name);
                        userFound = true;
                    }
                    else
                    {
                        Console.Write("No user by that name. Try again?[y/n] ");

                        string input = Console.ReadLine();
                        input = input.ToLower().Trim();

                        if (input == "n" || input == "no")
                        {
                            return new User("::INVALID::", "::INVALID::");
                        }
                    }
                }

                using (var passBuilder = new System.Security.SecureString())
                {
                    Console.Write("password: ");
                    bool passFinished = false;

                    while (!passFinished)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);

                        if (key.Key == ConsoleKey.Enter)
                        {
                            passFinished = true;
                            Console.WriteLine();
                        }
                        else if (key.Key == ConsoleKey.Backspace)
                        {
                            Console.Write("\b");
                            passBuilder.RemoveAt(passBuilder.Length);
                        }
                        else if (((int)key.Key >= 65) && ((int)key.Key <= 90))
                        {
                            Console.Write("*");
                            passBuilder.AppendChar(key.KeyChar);
                        }
                    }

                    if (usr.Authenticate(passBuilder))
                    {
                        success = true;
                    }
                    else
                    {
                        Console.Write("Invalid username or password. Try again?[y/n] ");
                        string input = Console.ReadLine();
                        input = input.ToLower().Trim();

                        if (input == "n" || input == "no")
                        {
                            return new User("::INVALID::", "::INVALID::");
                        }
                    }
                }
            }

            return usr;
        }
    }
}
