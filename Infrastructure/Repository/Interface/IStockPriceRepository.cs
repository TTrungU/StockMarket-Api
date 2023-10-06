using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interface
{
    public interface IStockPriceRepository:IRepositoryBase<StockPrice>
    {
        Task<IEnumerable<StockPrice>> GetByStockSymbol(string symbol);
        Task<IEnumerable<StockPrice>> GetByTimeStamp(string symbol, DateTime startDate, DateTime endDate);

    }
}
