using Application.Dtos;
using Application.Model;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUserAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task CreateUserAsync(CreateUserModel user);
        Task DeleteUserAsync(int id);
    }
}
