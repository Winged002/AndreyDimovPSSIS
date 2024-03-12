using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace WelcomeExtended.Data
{
    public class UserData
    {
        private readonly List<User> _users;
        private int _nextId;

        //private User user = new User();

        public UserData(List<User> users, int nextId)
        {
            //_users = new List<User>();
            //_nextId = 0;
            _users = users;
            _nextId = nextId;
        }

        public UserData()
        {
            _users = new List<User>();
            _nextId = 0;
        }

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            //if (user != null)
            //{
            user.Id = _nextId++;
                _users.Add(user);
          //}
        }

        public void DeleteUser(User user)
        {
            _users.Remove(user);
        }

        public bool ValidateUser(string names, string password)
        {
            foreach(var user in _users)
            {
                if(user.Names == names && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidateUserLambda(string names, string password)
        {
            return _users.Where(x => x.Names == names && x.Password == password).FirstOrDefault() != null ? true : false;
        }

        public bool ValidateUserLinq(string names, string password)
        {
            var ret = from user in _users
                      where user.Names == names && user.Password == password
                      select user.Id;
            return ret != null ? true : false;
        }

        public User GetUser(string names, string password)
        {
            foreach (var user in _users)
            {
                if (user.Names == names && user.Password == password)
                {
                    return user;
                }
            }
            throw new InvalidOperationException();
        }

        public void SetActive(string names, DateTime date)
        {
            foreach (var user in _users)
            {
                if (user.Names == names)
                {
                    user.Expires = date;
                }
            }
        }
        public void AssignUserRole(string names, UserRolesEnum role)
        {
            foreach (var user in _users)
            {
                if (user.Names == names)
                {
                    user.Role = role;
                }
            }
        }
    }
}
