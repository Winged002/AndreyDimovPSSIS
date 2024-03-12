using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using Welcome.Model;
using static WelcomeExtended.Others.Delegates;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using WelcomeExtended.Loggers;

namespace WelcomeExtended
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                ////example2
                //var user = new user
                //{
                //    names = "john smith",
                //    password = "password123",
                //    role = userrolesenum.student,
                //    email = "john.smith@yahoo.com",
                //    fakultetennomer = "123456789"
                //};
                //var viewmodel = new userviewmodel(user);
                //var view = new userview(viewmodel);
                //view.display();

                //view.displayerror();

                UserData userData = new UserData();
                LoginLogger logger = new LoginLogger("D:/C:/Users/Admin/Desktop/StudentInformationSystem/WelcomeExtended/Loggers/LoginLogger.txt");
                ErrorLogger errorLogger = new ErrorLogger("D:/C:/Users/Admin/Desktop/StudentInformationSystem/WelcomeExtended/Loggers/ErrorLogger.txt");

                User studentUser = new User()
                {
                    Names = "Student1",
                    Password = "1234",
                    Role = UserRolesEnum.STUDENT
                };
                
                userData.AddUser(studentUser);

                User studentUser2 = new User()
                {
                    Names = "Student2",
                    Password = "5215",
                    Role = UserRolesEnum.STUDENT
                };
                userData.AddUser(studentUser2);

                User teacherUser = new User()
                {
                    Names = "Teacher1",
                    Password = "12543",
                    Role = UserRolesEnum.PROFESSOR
                };
                userData.AddUser(teacherUser);

                User adminUser = new User()
                {
                    Names = "Admin",
                    Password = "54623",
                    Role = UserRolesEnum.ADMIN
                };
                userData.AddUser(adminUser);

                User user = new User();
                Console.WriteLine("Write your username:");
                var username = Console.ReadLine();
                if (username == null)
                {
                    throw new Exception("The username cannot be null.");
                }

                user.Names = username;

                Console.WriteLine("Write your password:");
                var password = Console.ReadLine();
                if (password == null)
                {
                    throw new Exception("The password cannot be null");
                }

                user.Password = password;
                
                if(userData.ValidateUser(user.Names, user.Password))
                {
                    UserHelper.GetUser(userData, user.Names, user.Password);
                    logger.LogLogin(user.Names);
                }else
                {
                    errorLogger.LogError("Invalid username or password.");
                    throw new Exception("The user is not found!");
                }

            }
            catch (Exception e)
            {
                var log = new ActionOnError(Log);
                log(e.Message);
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }
        }
    }
}