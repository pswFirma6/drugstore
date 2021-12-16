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
        private IEventRepository eventRepository;
        public EventController(DatabaseEventContext context)
        {
            eventRepository = new EventRepository(context);
            eventService = new PharmacyLibrary.Services.EventService(eventRepository);
        }

        [HttpPost]
        [Route("addEvent")]
        public void Add(Event e){
            eventService.Add(e);
        }
    }
}
