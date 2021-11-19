using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
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
            if(AreDatesAcceptable(offer.StartDate, offer.EndDate))
            {
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
    }
}
