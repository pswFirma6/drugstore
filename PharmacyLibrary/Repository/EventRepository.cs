using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository
{
    public class EventRepository : Repo<Event>, IEventRepository
    {

        public EventRepository(DatabaseEventContext context) : base(context)
        {

        }

        public void SaveEvent()
        {
            _eventContext.SaveChanges();
        }

    }
}
