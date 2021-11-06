using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    [Keyless]
   public class PharmacyMedicines
    {
        public int IdPharmacy { get; set; }
        public int IdMedicine { get; set; }

    }
}
