using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_API.DTO
{
    public class UserLoginDTO
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}