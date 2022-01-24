using MimeKit;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace PharmacyLibrary.Services
{
    public class NotificationService
    {
        private readonly INotificationRepository notificationRepository;
        private readonly IConfiguration _config;

        public NotificationService(INotificationRepository inotificationRepository, IConfiguration config)
        {
            notificationRepository = inotificationRepository;
            _config = config;
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
            notification.Name = "GalenPharm";
            notification.Date = DateTime.Now;
            notification.Read = false;
            var message = new Message(new string[] { "pswapoteka@gmail.com","pswgalenpharm@gmail.com", "pswzdravlje@gmail.com",
            "pswhemofarm@gmail.com"}, notification.Title, notification.Content + notification.Name);
            AddNotification(notification);
            SendEmail(message);
        }

        public void SendEmail(Message message)
        {
            var mailMessage = CreateEmailMessage(message);

            Send(mailMessage);
        }

        public MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            string hospitalEmail = _config.GetValue<string>("Email");
            emailMessage.From.Add(new MailboxAddress("", hospitalEmail));
         
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = "<!DOCTYPE html><body>" + message.Content + "<br></body></html>",
            };

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            string hospitalEmail = _config.GetValue<string>("Email");
            string password = _config.GetValue<string>("Password");
            using (var client = new SmtpClient())
            {
                try
                {
                     client.Connect("smtp.gmail.com", 465, true);
                     client.AuthenticationMechanisms.Remove("XOAUTH2");
                     client.Authenticate(hospitalEmail, password);

                     client.Send(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
