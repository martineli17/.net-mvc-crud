using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Crosscuting.Notification
{
    public class Notify : INotify
    {
        private readonly List<NotificationMessage> _notifications;
        public Notify()
        {
            _notifications = new List<NotificationMessage>();
        }
        public void AddNotification(NotificationMessage notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotification(ValidationResult notification)
        {
            foreach (var item in notification.Errors)
            {
                _notifications.Add(new NotificationMessage(item.ErrorMessage)); ;
            }
        }

        public void AddNotificationRange(List<NotificationMessage> notification)
        {
            _notifications.AddRange(notification);
        }

        public void ClearNotification()
        {
            _notifications.Clear();
        }

        public IReadOnlyList<NotificationMessage> GetNotifications()
        {
            return _notifications;
        }

        public bool HaveNotification()
        {
            return _notifications.Any();
        }
    }
}
