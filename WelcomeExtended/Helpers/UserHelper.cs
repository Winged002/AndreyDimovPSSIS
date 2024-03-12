using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    public static class UserHelper
    {
        static User ToString(this User user)
        {
            return user;
        }

        public static void ValidateCridentials(UserData user, string names, string password)
        {
            if (names == null || password == null)
            {
                Console.WriteLine("The field cannot be empty!");
            }
            user.ValidateUser(names, password);
        }

        public static User GetUser(UserData user, string names, string password)
        {
            return ToString(user.GetUser(names, password));
        }

    }
}
