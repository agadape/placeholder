using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple_API.models;

namespace Simple_API.data
{
    public interface InterfaceUserASP
    {
        IEnumerable<AspUsers> GetAllUsers();
        AspUsers RegisterUser(AspUsers user);
        AspUsers GetUserByUsername(string username);
        AspUsers UpdateUser(AspUsers user);
        void DeleteUser(string username);
        AspUsers? LoginUser(string username, string password);

    }
}