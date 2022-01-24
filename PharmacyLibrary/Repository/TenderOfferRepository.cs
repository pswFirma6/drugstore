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

        public TenderOfferRepository(DatabaseContext context) : base(context)
        {

        }

        public List<TenderOffer> GetOffers()
        {
            DbSet<TenderOffer>  table = _context.Set<TenderOffer>();
            var offers = table.Include(offer => offer.OfferItems).ToList();
            return offers;
        }
    }
}
