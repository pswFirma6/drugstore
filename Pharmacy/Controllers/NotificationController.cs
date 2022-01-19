using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly TenderOfferService tenderOfferService;
        private readonly TenderService tenderService;
        private readonly IConfiguration _config;


        public NotificationController(DatabaseContext context, IConfiguration config)
        {
            INotificationRepository notificationRepository = new NotificationRepository(context);
            notificationService = new NotificationService(notificationRepository);
            ITenderOfferRepository tenderOfferRepository = new TenderOfferRepository(context);
            tenderOfferService = new TenderOfferService(tenderOfferRepository);
            ITenderRepository tenderRepository = new TenderRepository(context);
            tenderService = new TenderService(tenderRepository);
            _config = config;
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

        [HttpPost]
        [Route("tenderNotification")]
        public void AddTenderNotification(TenderOffer offer)
        {
            notificationService.CreateTenderNotification(offer);
            string url = Environment.GetEnvironmentVariable("HOSPITAL_URL") ?? _config.GetValue<string>("HospitalUrl");
            tenderService.CloseTender(offer, url);
            tenderOfferService.MakeOfferWinner(offer);
        }

        [HttpGet]
        [Route("pharmacyName")]
        public string[] GetPharmacyName()
        {
            string[] pharmacyName = {Environment.GetEnvironmentVariable("NAME") ?? _config.GetValue<string>("Name") };
            return pharmacyName;
        }
    }
}
