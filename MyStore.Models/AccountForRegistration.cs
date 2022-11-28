
using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class AccountForRegistration
    {
        public AccountForRegistration(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
        public AccountForRegistration() { }

        [StringLength(20, MinimumLength = 5, 
            ErrorMessage = "Name length must be from 5 to 20 symbols!!!")]
        [Required(ErrorMessage = "This field must be filled!!!")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "This field must be filled!!!")]
        [EmailAddress(ErrorMessage = "Uncorrect email address!")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "This field must be filled!!!")]
        [MinLength(6, 
            ErrorMessage = "This field must be filled!!!")]
        public string Password { get; set; } = "";
    }
}
