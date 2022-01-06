using Microsoft.AspNetCore.Mvc;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    [ApiController]
    public class EventController : Controller
    {
        private readonly PharmacyLibrary.Services.EventService eventService;
        public EventController(DatabaseEventContext context)
        {
            eventService = new PharmacyLibrary.Services.EventService();
        }

        [HttpPost]
        [Route("addEvent")]
        public void Add(String eventName){
            eventService.CreateEventEntry(eventName);
        }
    }
}
