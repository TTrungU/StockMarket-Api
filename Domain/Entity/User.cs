using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class User : BaseEntity
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Email { get; set; }
        public string? HashedPassword { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
        public ICollection<WatchList>? WatchLists { get; set; }

    }
}
