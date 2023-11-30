using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interface
{
    public interface IWatchListRepository:IRepositoryBase<WatchList>
    {
        Task<WatchList> GetWatchListById(int userId, int stockId);
        
    }
}
