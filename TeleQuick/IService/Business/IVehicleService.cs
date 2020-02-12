using Business.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IService.Business
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> Get();
    }
}
