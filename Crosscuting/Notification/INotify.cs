using FluentValidation.Results;
using System.Collections.Generic;

namespace Crosscuting.Notification
{
    public interface INotify
    {
        void AddNotification(NotificationMessage notification);
        void AddNotification(ValidationResult notification);
        void AddNotificationRange(List<NotificationMessage> notification);
        void ClearNotification();
        bool HaveNotification();
        IReadOnlyList<NotificationMessage> GetNotifications();
    }
}
