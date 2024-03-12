using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace Welcome.ViewModel
{
    public class UserViewModel
    {
        private User _user;


        public UserViewModel (User user)
        {
            _user = user;
        }

        public string Names { 
            get { 
                return _user.Names; 
            } 
            set { 
                _user.Names = value; 
            } 
        }
        public string Password { 
            get { 
                return _user.Password; 
            } 
            set {
                string concat = _user.Names + value;
                _user.Password = concat;
            } 
        }
        public UserRolesEnum Role { 
            get { 
                return _user.Role; 
            } 
            set { 
                _user.Role = value; 
            } 
        }
      
        public int Id
        {
            get
            {
                return _user.Id;
            }
            set
            {
                _user.Id = value;
            }
        }

    }
}
