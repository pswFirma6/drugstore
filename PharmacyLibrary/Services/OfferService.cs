using Newtonsoft.Json;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class OfferService
    {
        private readonly IOfferRepository repository;
        private static readonly EventService eventService = new EventService();

        public OfferService(IOfferRepository IRepository)
        {
            repository = IRepository;
        }

        public void AddOffer(Offer offer)
        {
            if(AreDatesAcceptable(offer.StartDate, offer.EndDate))
            {
                repository.Add(offer);
                repository.Save();
                Event e = new Event();
                e.ApplicationName = "AppForPharmacy";
                e.ClickTime = DateTime.Now;
                e.Id = eventService.GetAll().Count + 1;
                e.Name = "Add new offer";
                eventService.Add(e);

            }
        }

        public bool AreDatesAcceptable(DateTime startDate, DateTime endDate)
        {
            return startDate < endDate;
        }

        public List<Offer> GetOffers()
        {
            Event e = new Event();
            e.ApplicationName = "AppForPharmacy";
            e.ClickTime = DateTime.Now;
            e.Id = eventService.GetAll().Count + 1;
            e.Name = "Show all offers";
            eventService.Add(e);
            return repository.GetAll();
        }

        public void SendOffer(Offer offer)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "offer-exchange", type: ExchangeType.Fanout);

                var message = offer;
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish("offer-exchange", string.Empty, null, body);
            }

        }
    }
}
