using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Stock : BaseEntity
    {
        public string? Symbol { get; set; }
        public string? CompanyName {get;set;}
        public decimal? MarketCap { get; set; }
        public string? Sector { get; set;}
        public string? Industry { get; set; }
        public string? StockType { get; set; }
        public ICollection<WatchList>? WatchLists { get; set; } 
        public ICollection<StockPrice>? StockPrices { get; set; }

    }
}
