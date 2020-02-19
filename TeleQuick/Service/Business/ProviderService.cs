using Business.Models;
using IDataAccess;
using IProvider;
using IService.Business;
using Provider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeleQuick.Core.IAutopista;
using TeleQuick.IAutopista;

namespace Service.Business
{
    public class ProviderService : IProviderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConnection _provider;

        public ProviderService(IUnitOfWork unitOfWork, IConnection provider)
        {
            _unitOfWork = unitOfWork;
            _provider = provider;
        }

        public async Task<IProviderAU> GetProvider(int idAccountSession)
        {
            AccountSession account = await _unitOfWork.AccountSessions.GetById(idAccountSession);

            IProviderAU provider = null;

            switch (account.Concessionary.GetAutopista())
            {
                case AutopistasConstants.AUSA:
                    provider = new ProviderAUSA(_provider);
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

            return provider;
        }
    }
}
