using Business.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.IRestServices
{
    public interface IParametersRestService
    {
        Task<IEnumerable<Province>> GetProvinces();

        Task<IEnumerable<OptIn>> GetOptines();
    }
}
