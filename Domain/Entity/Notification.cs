using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Notification : BaseEntity
    {
        public string? Content { get; set; }
        public DateTime? CreateAt { get; set; }
        public bool? IsRead { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
