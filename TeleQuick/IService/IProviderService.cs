using TeleQuick.Business.Models;
using IProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IService.TeleQuick.Business
{
    public interface IProviderService
    {
        Task<IProviderAU> GetProvider(AccountSession accountSession);
    }
}
