using Application.Dtos;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interface
{
    public interface IStockService
    {
        Task<IEnumerable<StockDto>> GetAllStockAsync();
        Task<StockDto> GetStockByIdAsync(int id);
    }
}
