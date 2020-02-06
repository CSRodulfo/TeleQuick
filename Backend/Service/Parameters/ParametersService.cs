using Business.IRestServices;
using Business.Parameters;
using IServices.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Parameters
{
    public class ParametersService : IParametersService
    {
        private readonly IParametersRestService parametersRestService;

        public ParametersService(IParametersRestService parametersRestService)
        {
            this.parametersRestService = parametersRestService;
        }


        public async Task<IEnumerable<OptIn>> GetOptines()
        {
            return await this.parametersRestService.GetOptines();
        }

        public async Task<IEnumerable<Province>> GetProvinces()
        {
            return await this.parametersRestService.GetProvinces();
        }
    }
}
