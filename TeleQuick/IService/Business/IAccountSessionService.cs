using Business.Models.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IService.Business
{
    public interface IAccountSessionService
    {
        Task<IEnumerable<AccountSession>> Get();
    }
}
