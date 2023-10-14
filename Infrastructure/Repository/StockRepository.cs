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
    public class StockRepository : RepositoryBase<Stock>, IStockRepository
    {
        public StockRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Stock>> GetAll()
        {
           return await FindAll().ToListAsync();
        }

        public async Task<Stock> GetById(int id)
        {
            return await FindByCondition(s=>s.Id==id).FirstOrDefaultAsync();

        }
    }
}
