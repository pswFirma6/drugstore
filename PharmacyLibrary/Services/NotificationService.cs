using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class NotificationService
    {
        private readonly INotificationRepository notificationRepository;

        public NotificationService(INotificationRepository inotificationRepository)
        {
            notificationRepository = inotificationRepository;
        }

        public void AddNotification(Notification notification)
        {
            notificationRepository.Add(notification);
            notificationRepository.Save();
        }

        public List<Notification> GetNotifications()
        {
            return notificationRepository.GetAll();
        }

        public void ReadNotification(Notification notification)
        {
            foreach (Notification existingNotification in notificationRepository.GetAll()){
                if(existingNotification.Id == notification.Id)
                {
                    existingNotification.Read = true;
                    notificationRepository.Save();
                    break;
                }   
            }
        }

        public void CreateTenderNotification(TenderOffer offer)
        {
            Notification notification = new Notification();
            notification.Title = "Tender results";
            notification.Content = "The winner of the tender " + offer.TenderId + " is pharmacy ";
            //notification.Name = offer.PharmacyName;
            notification.Date = DateTime.Now;
            notification.Read = false;

            AddNotification(notification);
        }
    }
}
