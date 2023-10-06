using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class WatchList
    {
        public int? UserId { get; set; }
        public int? StockId { get; set; }
        public User? User { get; set; }
        public Stock? Stock { get; set; }
    }
}
