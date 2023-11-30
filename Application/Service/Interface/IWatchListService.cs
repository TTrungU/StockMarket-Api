using Domain.Dtos;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interface
{
    public interface IWatchListService
    {
        Task CreateWathListAsync(WatchListDto watchList);
        Task DeleteWatchListAsync(int userId, int stockId);
        Task<IEnumerable<WatchListDto>> GetWatchListByUserIdAsync(int userId);
    }
}
