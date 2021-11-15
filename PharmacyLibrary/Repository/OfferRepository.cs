using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;
using PharmacyLibrary.IRepository;

namespace PharmacyLibrary.Repository
{
    public class OfferRepository: Repo<Offer>, IOfferRepository
    {
        public OfferRepository(DatabaseContext context):base(context)
        {

        }
    }
}
