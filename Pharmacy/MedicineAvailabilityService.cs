using Grpc.Core;
using PharmacyLibrary.DTO;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PharmacyLibrary.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy
{
    public class MedicineAvailabilityService : MedicineService.MedicineServiceBase
    {
        public override Task<MedicineAvailabilityResponse> checkMedicineAvailability(MedicineAvailabilityMessage request, ServerCallContext context)
        {
            DatabaseContext dbContext = new DatabaseContext();
            IMedicineRepository medicineRepository = new MedicineRepository(dbContext);
            PharmacyLibrary.Services.MedicineService medicineService = new PharmacyLibrary.Services.MedicineService(medicineRepository);

            MedicineDTO medicineDTO = new MedicineDTO
            {
                Name = request.MedicineName,
                Quantity = (int)request.MedicineQuantity
            };

            MedicineAvailabilityResponse response = new MedicineAvailabilityResponse();
            response.IsAvailable = medicineService.CheckMedicine(medicineDTO);

            return Task.FromResult(response);
        }

        public override Task<MedicineAvailabilityResponse> medicineUrgentProcurement(MedicineAvailabilityMessage request, ServerCallContext context)
        {
            DatabaseContext dbContext = new DatabaseContext();
            IMedicineRepository medicineRepository = new MedicineRepository(dbContext);
            PharmacyLibrary.Services.MedicineService medicineService = new PharmacyLibrary.Services.MedicineService(medicineRepository);

            MedicineDTO medicineDTO = new MedicineDTO
            {
                Name = request.MedicineName,
                Quantity = (int)request.MedicineQuantity
            };

            MedicineAvailabilityResponse response = new MedicineAvailabilityResponse();
            medicineService.OrderMedicine(medicineDTO);
            response.IsAvailable = true;

            return Task.FromResult(response);
        }
    }
}
