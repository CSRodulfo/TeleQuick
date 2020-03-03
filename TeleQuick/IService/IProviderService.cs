using TeleQuick.Business.Models;
using IProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TeleQuick.IService
{
    public interface IProviderService
    {
        IProviderAU GetProviderToLogin(AccountSession accountSession);

        IProviderAU GetProvider(AccountSession accountSession, IEnumerable<Vehicle> vehicles);
    }
}
