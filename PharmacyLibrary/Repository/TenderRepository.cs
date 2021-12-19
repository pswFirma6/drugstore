using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository
{
    public class TenderRepository : Repo<Tender>, ITenderRepository
    {
        public TenderRepository(DatabaseContext context) : base(context) { }
    }
}
