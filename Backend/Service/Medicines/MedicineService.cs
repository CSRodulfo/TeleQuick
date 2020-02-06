using Business.IRestServices;
using Business.MedicalInsurances;
using Business.Medicines;
using IServices.MedicalInsurances;
using IServices.Medicines;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Medicines
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRestService medicineRestService;

        public MedicineService(IMedicineRestService medicineRestService)
        {
            this.medicineRestService = medicineRestService;
        }

        public Task<IEnumerable<Item>> Search(string filter)
        {
            return this.medicineRestService.Search(filter);
        }

        public Task<IEnumerable<Item>> GetAllByDescription(string description)
        {
            return this.medicineRestService.GetAllByDescription(description);
        }

        public Task<IEnumerable<Item>> GetByFormula(int idFormula, string potency, int unitPotencyId, int packageDescriptionId)
        {
            return this.medicineRestService.GetByFormula(idFormula, potency, unitPotencyId, packageDescriptionId);
        }
    }
}
