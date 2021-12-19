using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository
{
    public class TenderItemRepository : Repo<TenderItem>, ITenderItemRepository
    {
        public TenderItemRepository(DatabaseContext context) : base(context) { }
    }
}
