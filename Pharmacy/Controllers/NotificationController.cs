using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyLibrary.DTO;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PharmacyLibrary.Services;
using PhramacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
   
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationService notificationService;

        public NotificationController(DatabaseContext context)
        {
            INotificationRepository notificationRepository = new NotificationRepository(context);
            notificationService = new NotificationService(notificationRepository);
        }

        [HttpPost]
        [Route("newNotification")]
        public void AddNotification(Notification notification)
        {
            notificationService.AddNotification(notification);
        }

        [HttpGet]
        [Route("allNotifications")]
        public List<Notification> GetNotifications()
        {
            return notificationService.GetNotifications();
        }

        [HttpPut]
        [Route("readNotification")]
        public void ReadNotification(Notification notification)
        {
            notificationService.ReadNotification(notification);
        }

    }
}
