using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.IRepository
{
    public interface ITenderOfferRepository: IRepo<TenderOffer>
    {
        List<TenderOffer> GetOffers();
    }
}
