using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Model.Enums;
using PharmacyLibrary.Repository;
using PharmacyLibrary.Services;
using PhramacyLibrary.Model;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PharmacyIntegrationTests
{
    public class MedicineTests
    {
        private MedicineService service;
        private DatabaseContext context = new DatabaseContext();
        private IMedicineRepository repository;

        [Fact]
        public void Add_medicine()
        {
            repository = new MedicineRepository(context);
            service = new MedicineService(repository);
            Medicine medicine = new Medicine
            (
                "Aspirin",
                "Galenika",
                MedicineType.ANALGESIC,
                "",
                false,
                "NONE",
                "3 times a day",
                0.3,
                50
            );

            List<Medicine> beforeAdding = service.GetAll();
            service.Add(medicine);
            List<Medicine> afterAdding = service.GetAll();

            (afterAdding.Count - beforeAdding.Count).ShouldNotBe(0);
        }
    }
}
