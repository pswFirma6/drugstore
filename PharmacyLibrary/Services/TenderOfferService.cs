using Newtonsoft.Json;
using PharmacyLibrary.DTO;
using PharmacyLibrary.Exceptions;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class TenderOfferService
    {
        private readonly ITenderOfferRepository tenderOfferRepository;
        private readonly TenderOfferItemService tenderOfferItemService;
        private readonly DatabaseContext context;

        public TenderOfferService(ITenderOfferRepository iRepository)
        {
            tenderOfferRepository = iRepository;
            context = new DatabaseContext();
            ITenderOfferItemRepository itemRepository = new TenderOfferItemRepository(context);
            tenderOfferItemService = new TenderOfferItemService(itemRepository);
        }

        public List<TenderOffer> GetTenderOffers()
        {
            return tenderOfferRepository.GetOffers();
        }

        public List<TenderOfferDto> GetTenderOffersWithItems()
        {
            List<TenderOfferDto> tenderOffersWithItems = new List<TenderOfferDto>();
            foreach (TenderOffer tenderOffer in GetTenderOffers())
            {
                TenderOfferDto dto = new TenderOfferDto
                {
                    Id = tenderOffer.Id,
                    TenderId = tenderOffer.TenderId,
                    TenderOfferItems = tenderOfferItemService.GetTenderOfferItems(tenderOffer.Id),
                    CreationDate = tenderOffer.CreationDate.ToString(),
                    HospitalApiKey = ""
                };
                tenderOffersWithItems.Add(dto);
            }
            return tenderOffersWithItems;
        }

        public void AddTenderOffer(TenderOfferDto dto, string apiKey)
        {
            ITenderRepository tenderRepository = new TenderRepository(context);
            TenderService tenderService = new TenderService(tenderRepository);

            TenderOffer tenderOffer = new TenderOffer
            {
                Id = GetLastID() + 1,
                TenderId = dto.TenderId,
                CreationDate = DateTime.Now
            };
            SetTenderOfferItems(dto.TenderOfferItems, tenderOffer);
            tenderOfferRepository.Add(tenderOffer);
            tenderOfferRepository.Save();

            dto.HospitalApiKey = tenderService.FindById(dto.TenderId).HospitalApiKey;
            dto.TenderId = tenderService.FindById(dto.TenderId).HospitalTenderId;


            var factory = new ConnectionFactory
            {
                HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost",
                UserName = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest",
                Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest",
            };

            try
            {
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "tender-offer-exchange-" + apiKey, type: ExchangeType.Fanout);

                dto.Id = tenderOffer.Id;
                var message = dto;
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                    channel.BasicPublish("tender-offer-exchange-" + apiKey, String.Empty, null, body);
                }
            }
            catch
            {
                throw new CustomNotFoundException("Sftp server refuses to connect!");
            }

        }

        private int GetLastID()
        {
            List<TenderOffer> offers = GetTenderOffers();
            if (offers.Count == 0)
            {
                return 0;
            }
            return offers[offers.Count - 1].Id;
        }

        private TenderOffer SetTenderOfferItems(List<TenderOfferItemDto> dtos, TenderOffer offer)
        {
            foreach (TenderOfferItemDto dto in dtos)
            {
                offer.AddOfferItem(offer, dto.Name, dto.Quantity, dto.Price);
            }
            return offer;
        }

        public void MakeOfferWinner(TenderOffer offer)
        {
            offer.IsWinner = true;
            tenderOfferRepository.Update(offer);
            tenderOfferRepository.Save();
        }

    }
}
