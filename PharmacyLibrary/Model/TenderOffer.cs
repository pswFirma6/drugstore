using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class TenderOffer
    {
        public int Id { get; set; }
        public int TenderId { get; set; }
        public bool IsWinner { get; set; } = false;
        public DateTime CreationDate { get; set; }

        private readonly List<TenderOfferItem> _offerItems = new List<TenderOfferItem>();
        public IReadOnlyCollection<TenderOfferItem> OfferItems => _offerItems;

        public TenderOffer() { }

        public TenderOffer(int id, int tenderId, DateTime creationDate)
        {
            Id = id;
            TenderId = tenderId;
            CreationDate = creationDate;
        }

        public void AddOfferItem(TenderOffer offer, string name, int quantity, double price)
        {
            var offerItem = new TenderOfferItem(offer, name, quantity, price);
            _offerItems.Add(offerItem);
        }
    }
}
