using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class StockDto
    {
        public int Id { get; set; }
        public string? Symbol { get; set; }
        public string? CompanyName { get; set; }
        public decimal? MarketCap { get; set; }
        public string? Sector { get; set; }
        public string? Industry { get; set; }
        public string? StockType { get; set; }
    }
}
