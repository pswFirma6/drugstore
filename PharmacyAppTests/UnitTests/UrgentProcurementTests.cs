using PharmacyLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using Shouldly;

namespace PharmacyAppTests.UnitTests
{
    public class UrgentProcurementTests
    {
        private PharmacyMedicinesService pharmacyMedicinesService;

        [Fact]
        public void CheckIfEnoughAmount()
        {
            var stubRepository = new Mock<IPharmacyMedicinesRepository>();
            pharmacyMedicinesService = new PharmacyMedicinesService(stubRepository.Object);

            List<PharmacyMedicines> pharmacyMedicines = new List<PharmacyMedicines>();
            PharmacyMedicines pharmacyMedicine = new PharmacyMedicines { IdPharmacy = 1, IdMedicine = 2, Quantity = 30 };
            pharmacyMedicines.Add(pharmacyMedicine);

            stubRepository.Setup(m => m.GetAll()).Returns(pharmacyMedicines);

            bool ifEnoughAmount = pharmacyMedicinesService.IsEnoughAmount(2, 15);

            ifEnoughAmount.ShouldBeTrue();
        }

        [Fact]
        public void CheckIfNotEnoughAmount()
        {
            var stubRepository = new Mock<IPharmacyMedicinesRepository>();
            pharmacyMedicinesService = new PharmacyMedicinesService(stubRepository.Object);

            List<PharmacyMedicines> pharmacyMedicines = new List<PharmacyMedicines>();
            PharmacyMedicines pharmacyMedicine = new PharmacyMedicines { IdPharmacy = 1, IdMedicine = 2, Quantity = 30 };
            pharmacyMedicines.Add(pharmacyMedicine);

            stubRepository.Setup(m => m.GetAll()).Returns(pharmacyMedicines);

            bool ifEnoughAmount = pharmacyMedicinesService.IsEnoughAmount(2, 40);

            ifEnoughAmount.ShouldBeFalse();
        }

        [Fact]
        public void Medicine_procurement()
        {
            var stubRepository = new Mock<IPharmacyMedicinesRepository>();
            pharmacyMedicinesService = new PharmacyMedicinesService(stubRepository.Object);

            List<PharmacyMedicines> pharmacyMedicines = new List<PharmacyMedicines>();
            PharmacyMedicines pharmacyMedicine = new PharmacyMedicines { IdPharmacy = 1, IdMedicine = 2, Quantity = 30 };
            pharmacyMedicines.Add(pharmacyMedicine);

            stubRepository.Setup(m => m.GetAll()).Returns(pharmacyMedicines);
            stubRepository.Setup(m => m.Update(pharmacyMedicine)).Verifiable();

            pharmacyMedicinesService.UpdatePharmacyMedicineQuantity(1,2,10);

            pharmacyMedicines[0].Quantity.ShouldBe(20);
        }
    }
}
