using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        public string Names { get; set; }
        public string Password { get; set; }
        public UserRolesEnum Role { get; set; }
        //public string Email { get; set; }
        //public string FakultetenNomer { get; set; }
        public virtual int Id { get; set; }
        public DateTime Expires { get; set; }

        public User()
        {

        }
        public User(string names, string password, UserRolesEnum role, /*string email, string fakultetenNomer,*/ int id)
        {
            Names = names;
            Password = password;
            Role = role;
            //Email = email;
            //FakultetenNomer = fakultetenNomer;
            Id = id;
        }

    }
}
