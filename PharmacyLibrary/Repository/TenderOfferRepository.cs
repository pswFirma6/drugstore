using Microsoft.EntityFrameworkCore;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmacyLibrary.Repository
{
    public class TenderOfferRepository: Repo<TenderOffer>, ITenderOfferRepository
    {
        readonly DatabaseContext _context = new DatabaseContext();
        private DbSet<TenderOffer> table;

        public TenderOfferRepository(DatabaseContext context) : base(context)
        {

        }

        public List<TenderOffer> GetOffers()
        {
            table = _context.Set<TenderOffer>();
            var offers = table.Include(offer => offer.OfferItems).ToList();
            return offers;
        }
    }
}
