using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class EventService
    {
        private readonly EventRepository eventRepository;

        public EventService()
        {
            eventRepository = new EventRepository(new DatabaseEventContext());
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
            eventRepository.SaveEvent();
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
            eventRepository.SaveEvent();
        }

        public void CreateEventEntry(String eventName)
        {
            Event e = new Event();
            e.Id = GetAll().Count + 1;
            e.ApplicationName = "AppForPharmacy";
            e.ClickTime = DateTime.Now;
            e.Name = eventName;
            Add(e);
        }
    }
}
