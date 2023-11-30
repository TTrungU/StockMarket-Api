using Domain.Entity;
using Infrastructure.Data;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class WatchListRepository:RepositoryBase<WatchList>,IWatchListRepository
    {
        public WatchListRepository(DataContext dataContext) : base(dataContext) { }

        public async Task<WatchList> GetWatchListById(int userId, int stockId)
        {
            return await FindByCondition(w => w.UserId == userId && w.StockId == stockId).FirstOrDefaultAsync();
        }
    }
}
