using AuthenticateApi.LoginModel;
using AuthenticateApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticateApi.Repos
{
    public interface IRepository
    {
        bool UsernameExist(string username);

        User GetUser(UserLogin login);

        User GetUserDetails(string username);

        User Register(User user);
    }
}
