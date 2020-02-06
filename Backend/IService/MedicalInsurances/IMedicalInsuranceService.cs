using System.Collections.Generic;
using System.Threading.Tasks;
using Business.MedicalInsurances;

namespace IServices.MedicalInsurances
{
    public interface IMedicalInsuranceService
    {
        Task<List<MedicalInsurance>> GetAll();
    }
}
