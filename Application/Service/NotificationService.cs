using Application.Service.Interface;
using AutoMapper;
using Domain.Dtos;
using Domain.Entity;
using Domain.Exceptions;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository  _notificationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public NotificationService(IUserRepository userRepository, IMapper mapper,INotificationRepository notificationRepository)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
            _userRepository = userRepository;
        }

        public async Task CreateNotificationAsync(NotificationDto notificationDto)
        {
            if (!_userRepository.IsUserExist(notificationDto.UserId))
                throw new NotFoundException($"User with id {notificationDto.UserId} was not found");

            var notification = _mapper.Map<Notification>(notificationDto);
            _notificationRepository.Create(notification);
            await _notificationRepository.SaveAsync();
        }

        public async Task DeleteNotificationAsync(int notificationId)
        {
            var notification = await _notificationRepository.FindByCondition(n => n.Id == notificationId).FirstOrDefaultAsync();
            if (notification == null)
                throw new NotFoundException($"Notification with id ${notificationId} was not found");

            _notificationRepository.Delete(notification);
            await _notificationRepository.SaveAsync();
        }

        public async Task<IEnumerable<NotificationDto>> GetNotificatioṇByUserIdAsync(int userId)
        {
            var notification = await _notificationRepository.FindByCondition(n => n.UserId == userId).ToListAsync();

            return _mapper.Map<IEnumerable<NotificationDto>>(notification);
        }
    }
}
