using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string TargetName { get; set; }

        public string Text { get; set; }

        public DateTime When { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string TargetId { get; set; }
    }
}
