using Grpc.Core;
using PharmacyLibrary.DTO;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PharmacyLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy
{
    public class MedicineAvailabilityService : NetGrpcService.NetGrpcServiceBase
    {
        private readonly MedicineService service;
        private readonly DatabaseContext context = new DatabaseContext();

        public MedicineAvailabilityService()
        {
            IMedicineRepository repository = new MedicineRepository(context);
            service = new MedicineService(repository);
        }

        public override Task<MedicineAvailabilityResponse> transfer(MedicineAvailabilityMessage request, ServerCallContext context)
        {
            MedicineAvailabilityResponse response = new MedicineAvailabilityResponse();
            MedicineDTO dto = new MedicineDTO { Name = request.MedicineName, Quantity = (int)request.MedicineQuantity };
            response.Response = service.CheckMedicine(dto).ToString();
            response.Status = "STATUS OK";
            Console.WriteLine("SALJE SERVER");
            return Task.FromResult(response);
        }
    }
}
