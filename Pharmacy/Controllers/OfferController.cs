using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PharmacyLibrary.Model;
using PharmacyLibrary.Model.DTOs;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly OfferDbContext _context;

        public OfferController(OfferDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("createOffer")]
        public IActionResult AddOffer()
        {
            Offer offer = new Offer("title", "content", DateTime.Now, new DateTime());
            _context.Offers.Add(offer);
            _context.SaveChanges();
            
            sendNotification(offer);
            
            return Ok(offer);

        }

        private void sendNotification(Offer offer)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("demo-queue",
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                var message = "ZDRAVO";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "demo-queue", null, body);
            };
        }
    }
}
