using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model
{
    public class StockPriceSeedData
    {
        [Name("Open")]
        public decimal? Open { get; set; }
        [Name("Price")]
        public decimal? Price { get; set; }
        [Name("Low")]
        public decimal? Low { get; set; }
        [Name("Date")]
        public DateTime? TimeStamp { get; set; }
  
   
    }
}
