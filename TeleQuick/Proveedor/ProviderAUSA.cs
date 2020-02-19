using Business.Models;
using IProvider;
using System;
using System.Threading.Tasks;
using TeleQuick.Core.IAutopista;
using TeleQuick.IAutopista;

namespace Provider
{
    public class ProviderAUSA  : IProviderAU
    {

        IConnection _connection;
        ILogin _login ;

        public ProviderAUSA(IConnection connection)
        {
            _connection = connection;
            _login = new TeleQuick.AutopistaAUSA.Login();
        }

        public async Task<AccountSession> ValidateConnection(AccountSession account)
        {
            try
            {

                this._connection.LoginWebPage(_login);


                throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

    }
}
