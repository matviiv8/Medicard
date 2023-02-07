using Medicard.Domain.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Domain.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            Messages = new HashSet<Message>();
        }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public ICollection<Message> Messages { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
