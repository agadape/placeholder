using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple_API.models;

namespace Simple_API.data
{
    public class UserASPEF : InterfaceUserASP
    {
        private readonly ApplicationDBContext _context;
        public UserASPEF(ApplicationDBContext context)
        {
            _context = context;
        }
        public void DeleteUser(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AspUsers> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public AspUsers GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public AspUsers? LoginUser(string username, string password)
        {
            var user = _context.AspUsers.FirstOrDefault(u => u.username == username);
            if (user == null)
                return null;

            var hashedPassword = Helpers.HashHelper.HashPassword(password);
            return user.password == hashedPassword ? user : null;
        }

        public AspUsers RegisterUser(AspUsers user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user), "User cannot be null");
                }
                user.password = Helpers.HashHelper.HashPassword(user.password);
                _context.AspUsers.Add(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Error registering user", ex);
            }
        }

        public AspUsers UpdateUser(AspUsers user)
        {
            throw new NotImplementedException();
        }
    }
}