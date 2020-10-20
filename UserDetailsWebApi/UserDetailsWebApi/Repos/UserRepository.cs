using AuthenticateApi.LoginModel;
using AuthenticateApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticateApi.Repos
{
    public class UserRepository : IRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context )
        {
            _context = context;
        }
        public User GetUser(UserLogin login)
        {
            var user = _context.Users.Where(u => u.Username == login.Username && u.Password == login.Password).FirstOrDefault();
            return user;
        }

        public User Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public bool UsernameExist(string username)
        {
            var user = _context.Users.Where(u => u.Username == username).FirstOrDefault();
            if(user!=null)
                return true;
            return false;
        }

        public User GetUserDetails(string username)
        {
            var user = _context.Users.Where(u => u.Username == username).FirstOrDefault();
            return user;
        }
    }
}
