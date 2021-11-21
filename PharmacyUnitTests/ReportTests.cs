using Moq;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model.Enums;
using PharmacyLibrary.Services;
using PhramacyLibrary.Model;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PharmacyUnitTests
{
    public class ReportTests
    {
        private ReportsService service;
        [Fact]
        public void CheckIfMedicineExists()
        {
            var stubRepo = new Mock<IMedicineRepository>();
            service = new ReportsService(stubRepo.Object);
            Medicine med = new Medicine(1, "Brufen", "Manufactorer", MedicineType.ANALGESIC, "", false, "none", "none", 1, 1);
            List<Medicine> medicines = new List<Medicine>();
            medicines.Add(med);
            stubRepo.Setup(m => m.GetAll()).Returns(medicines);

            Medicine m = service.GetMedicine("nonexistant medicine");

            m.ShouldBeNull();
        }
    }
}
