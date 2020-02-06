using Business.IRestServices;
using Business.MedicalInsurances;
using IServices.MedicalInsurances;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.MedicalInsurances
{
    public class MedicalInsuranceService : IMedicalInsuranceService
    {
        private readonly IMedicalInsuranceRestService medicalInsuranceRestService;

        public MedicalInsuranceService(IMedicalInsuranceRestService medicalInsuranceRestService)
        {
            this.medicalInsuranceRestService = medicalInsuranceRestService;
        }

        public Task<List<MedicalInsurance>> GetAll()
        {
            return this.medicalInsuranceRestService.GetAll();
        }
    }
}
