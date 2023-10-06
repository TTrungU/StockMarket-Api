using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interface
{
    public interface IUserRepository:IRepositoryBase<User>
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(int userId);
        void Create(User userId);
        void Update(User userId);
        void Delete(User userId);
        bool IsUserExist(int userId);
        bool IsEmailExisṭ(string email);
    }
}
