using Application.IO.Core.Domain.Source.Notifications.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.IO.Core.Domain.Source.Notifications
{
    [NotMapped]
    public class DomainNotification : IAppNotification
    {
        public Guid DomainNotificationId { get; private set; }
        public DateTime Timestamp { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }

        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Timestamp = DateTime.Now;
            Key = key;
            Value = value;
        }
    }
}
