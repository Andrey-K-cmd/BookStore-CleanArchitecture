using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class User
    {
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Email { get; } = string.Empty;    
        public string PasswordHash { get; } = string.Empty;
        public Role Role { get; }

        private User(Guid id, string name, string email, string paasswordHash, Role role)
        {
            Id = id;
            Name = name;
            Email = email;
            PasswordHash = paasswordHash;
            Role = role;
        }

        public static User Create(Guid id, string name, 
            string email, string paasswordHash, Role role)
        {   

            return new User(id, name, email, paasswordHash, role);
        }
    }
}
