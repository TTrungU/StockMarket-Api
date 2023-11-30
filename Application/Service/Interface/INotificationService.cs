using Domain.Dtos;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interface
{
    public interface  INotificationService
    {
        Task<IEnumerable<NotificationDto>> GetNotificatioṇByUserIdAsync(int userId);
        Task CreateNotificationAsync(NotificationDto notificationDto);
        Task DeleteNotificationAsync(int notificationId);
    }
}
