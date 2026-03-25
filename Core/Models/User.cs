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
        public string PaasswordHash { get; } = string.Empty;

        private User(Guid id, string name, string email, string paasswordHash)
        {
            Id = id;
            Name = name;
            Email = email;
            PaasswordHash = paasswordHash;
        }

        public static (User? user, string error) Create(Guid id, string name, 
            string email, string paasswordHash)
        {
            if (string.IsNullOrEmpty(name))
            {
                return (null, "Имя должно быть указано");
            }
            else if (string.IsNullOrEmpty(email))
            {
                return (null, "Email должен бытть указан");
            }
            else if (string.IsNullOrEmpty(paasswordHash))
            {
                return (null, "Пароль обязателен");
            }

            var user = new User(id, name, email, paasswordHash);

            return (user, string.Empty);
        }
    }
}
