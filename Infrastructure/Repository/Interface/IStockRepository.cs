using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interface
{
    public interface IStockRepository:IRepositoryBase<Stock>
    {
       Task<IEnumerable<Stock>> GetAll();
       Task<Stock> GetById(int id);
        
    }
}
