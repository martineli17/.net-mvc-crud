using System;
using System.Collections.Generic;
using System.Text;

namespace Crosscuting.Notification
{
    public class NotificationMessage
    {
        public string ErrorMessage { get; private set; }

        public NotificationMessage(string pMessage)
        {
            ErrorMessage = pMessage;
        }
    }
}
