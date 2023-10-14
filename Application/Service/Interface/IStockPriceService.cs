using Application.Dtos;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interface
{
    public interface IStockPriceService
    {
        Task<IEnumerable<StockPriceDto>> GetStockPriceBySymbolAsync(string symbol);
        Task<IEnumerable<StockPriceDto>> GetStockPriceByTimestamp(string symbol,DateTime startDate, DateTime endDate);
    }
}
