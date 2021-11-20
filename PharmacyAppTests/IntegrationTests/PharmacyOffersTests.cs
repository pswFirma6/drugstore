using Moq;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PharmacyLibrary.Services;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace PharmacyAppTests
{
    public class PharmacyOffersTests
    {
        private OfferService service;
        private DatabaseContext context = new DatabaseContext();
        private IOfferRepository repository;

        [Fact]
        public void Add_offer()
        {
            repository = new OfferRepository(context);
            service = new OfferService(repository);
            Offer offer = new Offer { Id = 1, Title = "Offer1", Content = "Offer1", StartDate = new DateTime(2021, 11, 11), EndDate = new DateTime(2021, 11, 30) };

            List<Offer> beforeAdding = service.GetOffers();
            service.AddOffer(offer);
            List<Offer> afterAdding = service.GetOffers();

            (afterAdding.Count - beforeAdding.Count).ShouldNotBe(0);
        }

        [Fact]
        public void Get_offers()
        {
            repository = new OfferRepository(context);
            service = new OfferService(repository);

            List<Offer> offers = new List<Offer>();

            offers = service.GetOffers();

            offers.ShouldNotBeEmpty();
        }

    }
}
