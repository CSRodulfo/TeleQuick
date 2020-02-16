using Business.Models.Business;
using IDataAccess;
using IService.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Business
{
    public class AccountSessionService : IAccountSessionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountSessionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/values
        public async Task<IEnumerable<AccountSession>> Get()
        {
            var allCustomers = _unitOfWork.AccountSessions.GetAllAccountSessionData();
            return await allCustomers;
        }
    }
}
