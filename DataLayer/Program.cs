using DataLayer.Database;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace DataLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                context.Add<DatabaseUser>(new DatabaseUser()
                {
                    Names = "user",
                    Password = "password",
                    Expires = DateTime.Now,
                    Role = UserRolesEnum.STUDENT
                });
                context.SaveChanges();
                var users = context.Users.ToList();
                //Console.ReadKey();
                Console.WriteLine("Write your username: ");
                var username = Console.ReadLine();
                if (username == null)
                {
                    throw new Exception("The username cannot be null.");
                }
                Console.WriteLine("Write your password: ");
                var password = Console.ReadLine();
                if (password == null)
                {
                    throw new Exception("The password cannot be null.");
                }
                var ret = from user in users
                          where user.Names == username && user.Password == password
                          select user.Id;
                if (ret != null)
                {
                    Console.WriteLine("Valid user! ");
                }
                else
                {
                    Console.WriteLine("Not valid username or password!");
                }
            }
        }
    }
}