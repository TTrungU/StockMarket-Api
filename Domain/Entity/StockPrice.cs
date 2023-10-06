using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class StockPrice:BaseEntity
    {
        public decimal? Open { get; set; }
        public decimal? Close { get; set; }
        public decimal? Price { get; set; }
        public decimal? Low { get; set; }
        public float?  Change { get; set; }
        public int? StockId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public decimal? Prediction { get; set; }
        public bool? IsAnomaly { get; set; }
        public Stock? Stock { get; set; }


    }
}
