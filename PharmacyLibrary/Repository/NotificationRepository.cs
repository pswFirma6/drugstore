using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository
{
    public class NotificationRepository : Repo<Notification>, INotificationRepository
    {
        public NotificationRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
