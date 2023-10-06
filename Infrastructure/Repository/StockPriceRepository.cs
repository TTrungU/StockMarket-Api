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

        public async Task<IEnumerable<StockPrice>> GetByStockSymbol(string symbol)
        {
            Expression<Func<StockPrice, bool>> expression = s=>s.Stock.Symbol == symbol;
            return await FindByCondition(expression).ToListAsync();
        }

        public Task<IEnumerable<StockPrice>> GetByTimeStamp(string symbol, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
