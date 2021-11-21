using PharmacyLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Shouldly;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PhramacyLibrary.Model;
using PharmacyLibrary.Model.Enums;

namespace PharmacyAppTests.UnitTests
{
    public class UrgentProcurementTests
    {
        private MedicineService medicineService;

        [Fact]
        public void CheckIfEnoughAmount()
        {
            var stubRepository = new Mock<IMedicineRepository>();
            medicineService = new MedicineService(stubRepository.Object);

            List<Medicine> medicines = new List<Medicine>();
            Medicine medicine = new Medicine
            {
                Id = 1,
                Name = "Brufen",
                Manufacturer = "Hemofarm",
                MedicineType = MedicineType.ANALGESIC,
                Description = "newMedicine",
                IsPrescribed = true,
                SideEffects = "None",
                RecommendedDose = "Two times per day",
                Intensity = 0.2,
                Quantity = 30
            };
            medicines.Add(medicine);

            stubRepository.Setup(m => m.GetAll()).Returns(medicines);

            bool ifEnoughAmount = medicineService.IsEnoughAmount(1, 15);

            ifEnoughAmount.ShouldBeTrue();
        }

        [Fact]
        public void CheckIfNotEnoughAmount()
        {
            var stubRepository = new Mock<IMedicineRepository>();
            medicineService = new MedicineService(stubRepository.Object);

            List<Medicine> medicines = new List<Medicine>();
            Medicine medicine = new Medicine
            {
                Id = 1,
                Name = "Brufen",
                Manufacturer = "Hemofarm",
                MedicineType = MedicineType.ANALGESIC,
                Description = "newMedicine",
                IsPrescribed = true,
                SideEffects = "None",
                RecommendedDose = "Two times per day",
                Intensity = 0.2,
                Quantity = 30
            };
            medicines.Add(medicine);

            stubRepository.Setup(m => m.GetAll()).Returns(medicines);

            bool ifEnoughAmount = medicineService.IsEnoughAmount(1, 40);

            ifEnoughAmount.ShouldBeFalse();
        }

        [Fact]
        public void Medicine_procurement()
        {
            var stubRepository = new Mock<IMedicineRepository>();
            medicineService = new MedicineService(stubRepository.Object);

            List<Medicine> medicines = new List<Medicine>();
            Medicine medicine = new Medicine
            {
                Id = 1,
                Name = "Brufen",
                Manufacturer = "Hemofarm",
                MedicineType = MedicineType.ANALGESIC,
                Description = "newMedicine",
                IsPrescribed = true,
                SideEffects = "None",
                RecommendedDose = "Two times per day",
                Intensity = 0.2,
                Quantity = 30
            };
            medicines.Add(medicine);

            stubRepository.Setup(m => m.GetAll()).Returns(medicines);
            stubRepository.Setup(m => m.Update(medicine)).Verifiable();

            medicineService.UpdateMedicineQuantity(1, 10);

            medicines[0].Quantity.ShouldBe(20);
        }
    }
}
