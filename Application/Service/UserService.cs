using Application.Dtos;
using Application.Model;
using Application.Service.Interface;
using AutoMapper;
using Domain.Entity;
using Domain.Exceptions;
using Infrastructure.Repository.Interface;
using BCryptNet = BCrypt.Net.BCrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task CreateUserAsync(CreateUserModel user)
        {
            if (_userRepository.IsEmailExisṭ(user.Email))
            {
                throw new ConflictException($"Email: {user.Email} was already exist");
            }

            user.Password = BCryptNet.HashPassword(user.Password);
            var userEnity = _mapper.Map<User>(user);
            _userRepository.Create(userEnity);
            await _userRepository.SaveAsync();
        }

        public async Task<IEnumerable<UserDto>> GetAllUserAsync()
        {
            
            var user = await _userRepository.GetAllUserAsync();
               
            return _mapper.Map<IEnumerable<UserDto>>(user);
        }
            
        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
            throw new UserNotFoundException(id);

            return _mapper.Map<UserDto>(user);
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
                throw new UserNotFoundException(id);
             _userRepository.Delete(user);
            await _userRepository.SaveAsync();
        }
    }
}
