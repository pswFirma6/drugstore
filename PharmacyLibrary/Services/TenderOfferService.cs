using Newtonsoft.Json;
using PharmacyLibrary.DTO;
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
            return tenderOfferRepository.GetAll();
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
                    PharmacyName = tenderOffer.PharmacyName,
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
                Id = tenderOfferRepository.GetAll().Count + 1,
                TenderId = dto.TenderId,
                PharmacyName = dto.PharmacyName,
                CreationDate = DateTime.Now
            };
            tenderOfferRepository.Add(tenderOffer);
            tenderOfferRepository.Save();
            tenderOfferItemService.AddTenderOfferItems(SetTenderOfferItems(dto.TenderOfferItems, tenderOffer.Id));

            dto.HospitalApiKey = tenderService.FindById(dto.TenderId).HospitalApiKey;
            dto.TenderId = tenderService.FindById(dto.TenderId).HospitalTenderId;
            dto.TenderOfferItems = SetTenderOfferItemsDto(dto.TenderOfferItems, tenderOffer.Id);

            var factory = new ConnectionFactory
            {
                HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost",
                UserName = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest",
                Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest",
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "tender-offer-exchange-" + apiKey, type: ExchangeType.Fanout);
                dto.Id = tenderOffer.Id;
                Console.WriteLine("Drugstore dto id:" + dto.Id);

                var message = dto;
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                Console.WriteLine("Drugstore body: " + body.Length);
                channel.BasicPublish("tender-offer-exchange-" + apiKey, String.Empty, null, body);
            }

        }

        private List<TenderOfferItemDto> SetTenderOfferItemsDto(List<TenderOfferItemDto> dtos, int tenderOfferId)
        {
            List<TenderOfferItemDto> items = new List<TenderOfferItemDto>();
            foreach (TenderOfferItemDto dto in dtos)
            {
                TenderOfferItemDto item = new TenderOfferItemDto()
                {
                    Name = dto.Name,
                    Quantity = dto.Quantity,
                    Price = dto.Price,
                    TenderOfferId = tenderOfferId
                };
                items.Add(item);
            }
            return items;
        }

        private List<TenderOfferItem> SetTenderOfferItems(List<TenderOfferItemDto> dtos, int tenderOfferId)
        {
            List<TenderOfferItem> items = new List<TenderOfferItem>();
            foreach (TenderOfferItemDto dto in dtos)
            {
                TenderOfferItem item = new TenderOfferItem()
                {
                    Name = dto.Name,
                    Quantity = dto.Quantity,
                    Price = dto.Price,
                    TenderOfferId= tenderOfferId
                };
                items.Add(item);
            }
            return items;
        }

        public void MakeOfferWinner(TenderOffer offer)
        {
            offer.isWinner = true;
            tenderOfferRepository.Update(offer);
            tenderOfferRepository.Save();
        }

    }
}
