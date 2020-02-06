using Business.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Parameters
{
    public interface IParametersService
    {
        Task<IEnumerable<Province>> GetProvinces();

        Task<IEnumerable<OptIn>> GetOptines();

    }
}
