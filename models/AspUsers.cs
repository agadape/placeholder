using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_API.models
{
    public class AspUsers
    {
        [Key]
        public string username { get; set; } = null!;
        public string password { get; set; } = null!;
        public string email { get; set; } = null!;
        public string phone { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string role { get; set; } = "user"; // Default role is user
    }
}