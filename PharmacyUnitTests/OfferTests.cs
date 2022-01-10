using Moq;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Services;
using PharmacyLibrary.Shared;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PharmacyAppTests.UnitTests
{
    public class OfferTests
    {
        private OfferService service;

        [Fact]
        public void Are_dates_correct()
        {
            var stubRepository = new Mock<IOfferRepository>();
            service = new OfferService(stubRepository.Object);
            Offer offer = new Offer { Id = 1, Title = "Offer1", Content = "Offer1", OfferDateRange = new DateRange(new DateTime(2021, 11, 11), new DateTime(2021, 11, 30)) };

            bool checkDates = service.AreDatesAcceptable(offer.OfferDateRange.StartDate, offer.OfferDateRange.EndDate);

            checkDates.ShouldBe(true);
        }

        [Fact]
        public void Are_dates_incorrect()
        {
            var stubRepository = new Mock<IOfferRepository>();
            service = new OfferService(stubRepository.Object);
            Offer offer = new Offer { Id = 1, Title = "Offer1", Content = "Offer1", OfferDateRange = new DateRange(new DateTime(2021, 11, 11),  new DateTime(2021, 09, 30) )};

            bool checkDates = service.AreDatesAcceptable(offer.OfferDateRange.StartDate, offer.OfferDateRange.EndDate);

            checkDates.ShouldBe(false);
        }

        [Fact]
        public void Add_offer()
        {
            var stubRepository = new Mock<IOfferRepository>();
            service = new OfferService(stubRepository.Object);
            List<Offer> offers = new List<Offer>();
            Offer offer = new Offer { Id = 2, Title = "Offer1", Content = "Offer1", OfferDateRange=new DateRange(new DateTime(2021, 11, 11), new DateTime(2021, 11, 30) )};

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
            Offer offer = new Offer { Id = 1, Title = "Offer1", Content = "Offer1", OfferDateRange = new DateRange(new DateTime(2021, 11, 11), new DateTime(2021, 11, 30) )};

            offers.Add(offer);

            stubRepository.Setup(m => m.GetAll()).Returns(offers);

            offers = service.GetOffers();

            offers.ShouldNotBeEmpty();
        }

    }
}
