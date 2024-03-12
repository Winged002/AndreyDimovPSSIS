using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;
using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView
    {
        private UserViewModel _viewModel;

        public UserView(UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public string Names
        {
            get
            {
                return _viewModel.Names;
            }
            set
            {
                _viewModel.Names = value;
            }
        }
        public string Password
        {
            get
            {
                return _viewModel.Password;
            }
            set
            {
                string concat = _viewModel.Names + value;
                _viewModel.Password = concat;
            }
        }
        public UserRolesEnum Role
        {
            get
            {
                return _viewModel.Role;
            }
            set
            {
                _viewModel.Role = value;
            }
        }
        //public string Email
        //{
        //    get
        //    {
        //        return _viewModel.Email;
        //    }
        //    set
        //    {
        //        _viewModel.Email = value;
        //    }
        //}
        //public string FakultetenNomer
        //{
        //    get
        //    {
        //        return _viewModel.FakultetenNomer;
        //    }
        //    set
        //    {
        //        _viewModel.FakultetenNomer = value;
        //    }
        //}
        public int Id
        {
            get
            {
                return _viewModel.Id;
            }
            set
            {
                _viewModel.Id = value;
            }
        }

        public void Display()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("User: " + Names);
            Console.WriteLine("Role: " + Role);
            //Console.WriteLine("Email: " + Email);
            //Console.WriteLine("Fakulteten nomer: " + FakultetenNomer);
            Console.WriteLine("Id: " + Id);
        }

        public void DisplayError()
        {
            throw new Exception("Error!");
        }
    }
}
