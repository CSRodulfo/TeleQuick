using Business.Common;
using Business.MedicalInsurances;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.IRestServices
{
    public interface IMedicalInsuranceRestService
    {
        Task<List<MedicalInsurance>> GetAll();
    }
}
