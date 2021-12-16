using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class EventService
    {
        private readonly IEventRepository eventRepository;
        public EventService(IEventRepository iEventRepository)
        {
            eventRepository = iEventRepository;
        }
        public List<Event> GetAll()
        {
            return eventRepository.GetAll();
        }
        public Event FindById(int id)
        {
            return eventRepository.FindById(id);
        }
        public void Add(Event e)
        {
            eventRepository.Add(e);
            eventRepository.Save();
        }
        public void Update(Event e)
        {
            eventRepository.Update(e);
        }
        public void Delete(int id)
        {
            eventRepository.Delete(id);
        }
        public void Save()
        {
            eventRepository.Save();
        }
    }
}
