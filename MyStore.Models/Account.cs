using System.ComponentModel.DataAnnotations;


namespace MyStore.Models
{
    
    public class Account : IEntity
    {
        public Account(Guid id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            PasswordHash = password;
        }
        public Account()
        {

        }
        public Guid Id { get; set; }
        [MinLength(3)]
        public string Name { get; set; } = "";
        
        [EmailAddress]
        public string Email { get; set; } = "";
        [MinLength(6)]
        public string PasswordHash { get; set; } = "";
        
    }
}
