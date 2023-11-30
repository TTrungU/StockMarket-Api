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
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext):base(dataContext){}

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await FindByCondition(user => user.Id.Equals(userId)).FirstOrDefaultAsync();
        }

        public bool IsEmailExisṭ(string email)
        {
            return IsExist(user => user.Email == email);
        }

        public bool IsUserExist(int userId)
        {
           return IsExist(user => user.Id ==userId);
        }

        public bool IsUserExist(int? userId)
        {
            return IsExist(user => user.Id == userId);
        }
    }
}
