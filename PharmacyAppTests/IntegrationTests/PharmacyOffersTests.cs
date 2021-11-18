using Moq;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
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

        [Fact]
        public void Add_offer()
        {
            var stubRepository = new Mock<IOfferRepository>();
            service = new OfferService(stubRepository.Object);
            List<Offer> offers = new List<Offer>();
            Offer offer = new Offer { Id = 1, Title = "Offer1", Content = "Offer1", StartDate = new DateTime(2021, 11, 11), EndDate = new DateTime(2021, 11, 30), PharmacyName = "Pharmacy1" };

            stubRepository.Setup(m => m.Add(offer)).Callback((Offer o) => offers.Add(o));

            service.AddOffer(offer);

            offers.ShouldNotBeEmpty();
        }

        [Fact]
        public void Get_offers()
        {
            var stubRepository = new Mock<IOfferRepository>();
            service = new OfferService(stubRepository.Object);

            List<Offer> offers = new List<Offer>();
            Offer offer = new Offer { Id = 1, Title = "Offer1", Content = "Offer1", StartDate = new DateTime(2021, 11, 11), EndDate = new DateTime(2021, 11, 30), PharmacyName = "Pharmacy1" };
            offers.Add(offer);

            stubRepository.Setup(m => m.GetAll()).Returns(offers);

            offers = service.GetOffers();

            offers.ShouldNotBeEmpty();
        }

    }
}
