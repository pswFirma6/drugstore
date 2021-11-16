using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository
{
    public class PharmacyMedicinesRepository : Repo<PharmacyMedicines>, IPharmacyMedicinesRepository
    {
        public PharmacyMedicinesRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
