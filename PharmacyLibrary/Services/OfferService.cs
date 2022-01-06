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

        public OfferService(IOfferRepository IRepository)
        {
            repository = IRepository;
        }

        public void AddOffer(Offer offer)
        {
            if(AreDatesAcceptable(offer.OfferDateRange.StartDate, offer.OfferDateRange.EndDate))
            {
                offer.Id = repository.GetAll().Count + 1;
                repository.Add(offer);
                repository.Save();
            }
        }

        public bool AreDatesAcceptable(DateTime startDate, DateTime endDate)
        {
            return startDate < endDate;
        }

        public List<Offer> GetOffers()
        {
            return repository.GetAll();
        }

        public void SendOffer(Offer offer)
        {
            var factory = new ConnectionFactory
            {
                HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost",
                UserName = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest",
                Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest",
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "offer-exchange", type: ExchangeType.Fanout);

                offer.Id = repository.GetAll().Count;
                var message = offer;
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish("offer-exchange", string.Empty, null, body);
            }

        }
    }
}
