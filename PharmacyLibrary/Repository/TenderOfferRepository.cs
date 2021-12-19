using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository
{
    public class TenderOfferRepository: Repo<TenderOffer>, ITenderOfferRepository
    {
        public TenderOfferRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
