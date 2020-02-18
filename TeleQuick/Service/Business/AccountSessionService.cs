using Business.Models;
using Business.Models.Business;
using IDataAccess;
using IService.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeleQuick.Core.IAutopista;

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
            var allCustomers = _unitOfWork.AccountSessions.GetAllData();
            return await allCustomers;
        }

        public async Task<AccountSession> ValidateConnection(int idAccountSession)
        {

            AccountSession account =  await _unitOfWork.AccountSessions.GetById(idAccountSession);

            //account.Concessionary.Uri;



            throw new NotImplementedException();
        }

        public async Task<ILogin> Login()
        {

            var autopista = (AutopistasConstants)1;

            switch (autopista)
            {
                case AutopistasConstants.AUSA:
                    ILogin login = new TeleQuick.AutopistaAUSA.Login();
                    break;
                case AutopistasConstants.AUSOL:
                    break;
                case AutopistasConstants.AUBASA:
                    break;
                case AutopistasConstants.AUSUR:
                    break;
                case AutopistasConstants.AUOESTE:
                    break;
                case AutopistasConstants.CEAMSE:
                    break;
                default:
                    break;
            }

            return null;
        }

    }
}
