using Domain.Entity;
using Infrastructure.Data;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class StockPriceRepository : RepositoryBase<StockPrice>, IStockPriceRepository
    {
        public StockPriceRepository(DataContext dataContext):base(dataContext)
        {
            
        }

        public async Task<IEnumerable<StockPrice>> GetStockBySymbol(string symbol)
        {
            Expression<Func<StockPrice, bool>> expression = s =>s.Stock.Symbol == symbol;
            return await FindByCondition(expression).ToListAsync();
        }

        public async Task<IEnumerable<StockPrice>> GetStockByTimeStamp(string symbol, DateTime startDate, DateTime endDate)
        {
            Expression<Func<StockPrice,bool>> expression = s => s.Stock.Symbol == symbol && s.TimeStamp >= startDate && s.TimeStamp <= endDate;
            var query = from stock in _context.Stocks
                        join stockPrice in _context.StockPrices
                        on stock.Id equals stockPrice.StockId
                        where stock.Symbol == symbol
                        && stockPrice.TimeStamp >= startDate
                        && stockPrice.TimeStamp <= endDate
                        select stockPrice;
            return await FindByCondition(expression).ToListAsync();
        }
    }
}
