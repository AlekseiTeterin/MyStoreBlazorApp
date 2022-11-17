using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class AccountRegistration
    {
        public AccountRegistration(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
        public AccountRegistration() { }

        [MinLength(3)]
        public string Name { get; set; } = "";
        [EmailAddress]
        public string Email { get; set; } = "";
        [MinLength(6)]
        public string Password { get; set; } = "";
    }
}
