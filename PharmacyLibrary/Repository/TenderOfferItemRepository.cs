using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository
{
    public class TenderOfferItemRepository: Repo<TenderOfferItem>, ITenderOfferItemRepository
    {
        public TenderOfferItemRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
