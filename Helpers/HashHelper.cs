using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_API.Helpers
{
    public class HashHelper
    {
        //hash with bcrypt
        public static string HashPassword(string password)
        {
            using(var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                // Convert the password to a byte array and compute the hash
                var bytes = System.Text.Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);

                // Convert the byte array to a hexadecimal string
                return Convert.ToBase64String(hash);
            }
        }           
    }
}